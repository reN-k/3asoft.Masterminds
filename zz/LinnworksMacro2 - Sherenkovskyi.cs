using LinnworksAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LinnworksMacro
{
    public class LinnworksMacro : LinnworksMacroHelpers.LinnworksMacroBase
    {
        public void Execute(Guid[] orderIds)
        {
            Logger.WriteInfo("Start my test macro");

            foreach (var orderGuid in orderIds)
            {
                MyTestMacro2(orderGuid);
            }

            Logger.WriteInfo("End my test macro");            
        }

        private void MyTestMacro2(Guid orderGuidId)
        {
            var order = Api.Orders.GetOrderById(orderGuidId);
            int orderIntId = order.NumOrderId;
            string country = order.CustomerInfo.Address.Country;

            Logger.WriteInfo($"Order {orderIntId}:");

            if (country.ToUpper() == "IRELAND")
            {
                order.CustomerInfo.Address.PostCode = String.Empty;

                Logger.WriteInfo("Deleted post code  for irelands!");
            }

            if (String.IsNullOrEmpty(order.CustomerInfo.Address.PhoneNumber))
            {
                order.CustomerInfo.Address.PhoneNumber = "07900000003";

                Logger.WriteInfo("Added phone number (was empty).");
            }

            if (country.ToUpper() != "UNITED KINGDOM")
            {
                order.CustomerInfo.Address.PostCode = PostCodeFormating(order.CustomerInfo.Address.PostCode);

                Logger.WriteInfo("Post code changed for non United Kingdom.");
            }

            UpdateCustomerInfo(order);
            Logger.WriteInfo("Updated customer info.");

            CheckItems(order);
            Logger.WriteInfo("Checked order items");

            FoundSameAdressAndRelocateToFolder(order);

            Logger.WriteInfo("\n ======================================== \n");
        }

        private string PostCodeFormating(string postCode)
        {
            Regex nonDigit = new Regex(@"[^\d]+");

            if (String.IsNullOrEmpty(postCode))
            {
                return postCode;
            }

            string clearPostCode = nonDigit.Replace(postCode, "");

            return clearPostCode;
        }

        private void CheckItems(OrderDetails orderDetails)
        {
            var dictionarySkusNewItems = new Dictionary<string, int>();

            foreach (OrderItem item in orderDetails.Items)
            {
                var itemExtendedProperties = Api.Inventory.GetInventoryItemExtendedProperties(item.ItemId, new GetExtendedPropertyFilter());
                
                foreach (var property in itemExtendedProperties)
                {
                    var propertyName = property.ProperyName;

                    if (propertyName == "AdditonalItem1" || propertyName == "AdditonalItem2" || propertyName == "AdditonalItem3")
                    {
                        dictionarySkusNewItems.Add(property.PropertyValue, item.BinRacks[0].Quantity);
                        Logger.WriteInfo($"Founded additional item - {property.PropertyValue}");

                        break;
                    }
                }
            }

            if (dictionarySkusNewItems.Count > 0)
            {
                GetStockItemIdsBySKU stockItems = Api.Inventory.GetStockItemIdsBySKU(new GetStockItemIdsBySKURequest { SKUS = dictionarySkusNewItems.Keys.ToList() });
                
                foreach (var newItemModel in stockItems.Items)
                {
                    var itemAtDb = Api.Inventory.GetInventoryItemById(newItemModel.StockItemId);
                    var quantity = dictionarySkusNewItems[newItemModel.SKU];

                    Api.Orders.AddOrderItem(orderDetails.OrderId, newItemModel.StockItemId, newItemModel.SKU, orderDetails.FulfilmentLocationId,
                        quantity, new LinePricingRequest() { PricePerUnit = itemAtDb.PurchasePrice });

                    Logger.WriteInfo($"Added {itemAtDb.ItemTitle} x{quantity} to order {orderDetails.NumOrderId}");
                }
            }

        }

        private void UpdateCustomerInfo(OrderDetails details)
        {
            Api.Orders.SetOrderCustomerInfo(details.OrderId, details.CustomerInfo, false);           
           
        }

        private void FoundSameAdressAndRelocateToFolder(OrderDetails orderDetails)
        {
            var orderAdress = orderDetails.CustomerInfo.Address;

            var openOrders = Api.Orders.GetAllOpenOrders(new FieldsFilter(), new List<FieldSorting>(), orderDetails.FulfilmentLocationId, "");

            foreach (var openOrderGuid in openOrders)
            {
                var openOrder = Api.Orders.GetOrderById(openOrderGuid);
                var openOrderAdress = openOrder.CustomerInfo.Address;

                if (orderDetails.NumOrderId != openOrder.NumOrderId &&
                    String.Equals(orderAdress.FullName, openOrderAdress.FullName, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(orderAdress.Address1, openOrderAdress.Address1, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(orderAdress.Address2, openOrderAdress.Address2, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(orderAdress.Address3, openOrderAdress.Address3, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(orderAdress.Town, openOrderAdress.Town, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(orderAdress.Country, openOrderAdress.Country, StringComparison.OrdinalIgnoreCase))
                {
                    List<Guid> ordersGuids = new List<Guid>() { orderDetails.OrderId, openOrder.OrderId };

                    Api.Orders.AssignToFolder(ordersGuids, "Possible Merge Orders");

                    Logger.WriteInfo($"{orderDetails.NumOrderId} merged with {openOrder.NumOrderId}");
                }
            }
        }
    }
}