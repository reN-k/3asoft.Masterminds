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
            Logger.WriteInfo("Start my test macro 2");

            foreach (var orderGuid in orderIds)
            {
                MyTestMacro2(orderGuid);
            }

            Logger.WriteInfo("End my test macro 2");
        }

        private void MyTestMacro2(Guid orderGuidId)
        {
            var order = GetOrderDetails(orderGuidId);

            if (order.OrderId != null && order.OrderId != Guid.Empty)
            {
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
            }
            else Logger.WriteWarning($"Order is null or empty");
        }

        private string PostCodeFormating(string postCode)
        {
            Regex nonDigit = new Regex(@"[^\d]+");

            if (String.IsNullOrEmpty(postCode)) return postCode;

            string clearPostCode = nonDigit.Replace(postCode, "");

            return clearPostCode;
        }

        private void CheckItems(OrderDetails orderDetails)
        {
            var dictionarySkusNewItems = new Dictionary<string, int>();

            foreach (OrderItem item in orderDetails.Items)
            {
                var itemExtendedProperties = GetItemExtendedProperties(item.StockItemId, new GetExtendedPropertyFilter());

                if (itemExtendedProperties != null)
                {
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
            }

            if (dictionarySkusNewItems.Count > 0)
            {
                GetStockItemIdsBySKU stockItems = GetStockItemsBySku(dictionarySkusNewItems.Keys.ToList());

                if (stockItems != null)
                {
                    foreach (var newItemModel in stockItems.Items)
                    {
                        var itemAtDb = GetStockItemById(newItemModel.StockItemId);
                        var quantity = dictionarySkusNewItems[newItemModel.SKU];

                        bool result = AddItemToOrderResult(orderDetails.OrderId, newItemModel.StockItemId, newItemModel.SKU, orderDetails.FulfilmentLocationId,
                            quantity, new LinePricingRequest() { PricePerUnit = itemAtDb.PurchasePrice });

                        if (result) Logger.WriteInfo($"Added {itemAtDb.ItemTitle} x{quantity} to order {orderDetails.NumOrderId}");
                    }
                }
            }
        }

        private void FoundSameAdressAndRelocateToFolder(OrderDetails orderDetails)
        {
            var orderAdress = orderDetails.CustomerInfo.Address;

            var openOrders = GetOpenOrders(new FieldsFilter(), new List<FieldSorting>(), orderDetails.FulfilmentLocationId, String.Empty);

            if (openOrders != null)
            {
                foreach (var openOrderGuid in openOrders)
                {
                    var openOrder = GetOrderDetails(openOrderGuid);
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

                        MergeOrdersToFolder(ordersGuids, "Possible Merge Orders");
                    }
                }
            }
        }

        private OrderDetails GetOrderDetails(Guid orderGuid)
        {
            try
            {
                return Api.Orders.GetOrderById(orderGuid);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get order. Error -> {ex}");
                return new OrderDetails();
            }
        }

        private void UpdateCustomerInfo(OrderDetails details)
        {
            try
            {
                Api.Orders.SetOrderCustomerInfo(details.OrderId, details.CustomerInfo, false);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't update customer info. Error -> {ex}");
            }
        }

        private void MergeOrdersToFolder(List<Guid> ordersGuids, string folderName)
        {
            try
            {
                Api.Orders.AssignToFolder(ordersGuids, folderName);
                Logger.WriteInfo($"Orders assign to folder {folderName}");
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't merge orders.Error -> {ex}");
            }
        }

        private List<StockItemExtendedProperty> GetItemExtendedProperties(Guid itemGuid, GetExtendedPropertyFilter filter)
        {
            try
            {
                return Api.Inventory.GetInventoryItemExtendedProperties(itemGuid, filter);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get extended properties of {itemGuid}. Error -> {ex}");
                return null;
            }
        }

        private GetStockItemIdsBySKU GetStockItemsBySku(List<string> skus)
        {
            try
            {
                return Api.Inventory.GetStockItemIdsBySKU(new GetStockItemIdsBySKURequest { SKUS = skus });
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get stock item. Error -> {ex}");
                return null;
            }
        }

        private StockItemInv GetStockItemById(Guid itemGuid)
        {
            try
            {
                return Api.Inventory.GetInventoryItemById(itemGuid);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get item with id = {itemGuid}. Error -> {ex}");
                return null;
            }
        }

        private bool AddItemToOrderResult(Guid orderGuid, Guid itemGuid, string channelSku, Guid fulfulmentCenter, int quantity, LinePricingRequest request)
        {
            try
            {
                Api.Orders.AddOrderItem(orderGuid, itemGuid, channelSku, fulfulmentCenter, quantity, request);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't add item to order. Error -> {ex}");
                return false;
            }
        }
        private List<Guid> GetOpenOrders(FieldsFilter fieldsFilter, List<FieldSorting> fieldSortings, Guid locationGuid, string additionalFilter)
        {
            try
            {
                return Api.Orders.GetAllOpenOrders(fieldsFilter, fieldSortings, locationGuid, additionalFilter);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get open orders. Error -> {ex}");
                return null;
            }
        }
    }
}