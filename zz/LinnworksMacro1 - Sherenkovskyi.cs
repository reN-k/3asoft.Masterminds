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
        private readonly string _locationName = "XYZ";

        public void Execute()
        {
            Logger.WriteInfo("Start my test macro 1");

            MyTestMacro1();

            Logger.WriteInfo("End my test macro 1");
        }

        private void MyTestMacro1()
        {
            var locationNullableGuid = GetLocationGuidUsingName(_locationName);

            if (locationNullableGuid != null)
            {
                Guid locationGuid = locationNullableGuid.Value;

                List<BooleanFieldFilter> boolFieldsFilters = new List<BooleanFieldFilter>()
                {
                    new BooleanFieldFilter()
                    {
                        FieldCode = FieldCode.GENERAL_INFO_PARKED,
                        Value = false,
                    },
                    new BooleanFieldFilter()
                    {
                        FieldCode = FieldCode.GENERAL_INFO_LOCKED,
                        Value = false,
                    }
                };
                var fieldsFilter = new FieldsFilter()
                {
                    BooleanFields = boolFieldsFilters,
                };

                List<FieldSorting> fieldSortings = new List<FieldSorting>()
                {
                    new FieldSorting()
                    {
                        FieldCode = FieldCode.GENERAL_INFO_DATE,
                        Direction = 0 // ASC
                    }
                };

                var openOrdersAtLocation = GetOpenOrders(fieldsFilter, fieldSortings, locationGuid, String.Empty);

                if (openOrdersAtLocation != null)
                {
                    Logger.WriteInfo($"Founded {openOrdersAtLocation.Count} orders.");

                    foreach (var orderId in openOrdersAtLocation)
                    {
                        CheckOrderItems(orderId);
                    }
                }
            }
            else Logger.WriteError($"No location <{_locationName}> founded.");
        }

        private Guid? GetLocationGuidUsingName(string locationName)
        {
            var allLocations = GetAllStockLocations();

            if (allLocations != null)
            {
                var locationGuid = allLocations.Where(loca => loca.LocationName == locationName).FirstOrDefault()?.StockLocationId;

                return locationGuid;
            }
            else return null;
        }

        private void CheckOrderItems(Guid orderId)
        {
            var order = GetOrderDetails(orderId);

            if (order.OrderId != null && order.OrderId != Guid.Empty)
            {
                var orderItems = order.Items;
                bool orderCanMoveToDefaultLocation = true;
                bool orderHasServiceItem = false;

                var defaultLocationNullableGuid = GetLocationGuidUsingName("Default");
                var defaultLocationGuid = defaultLocationNullableGuid.Value;

                Logger.WriteInfo($"Work with order # {order.NumOrderId}:");

                foreach (var item in orderItems)
                {
                    GetStockLevelByLocationRequest stockLevelAtDefaultLocationRequest = new GetStockLevelByLocationRequest()
                    {
                        LocationId = defaultLocationGuid,
                        StockItemId = item.StockItemId
                    };
                    var stockLevelAtDefaultLocationResponse = GetStockLevelByLocation(stockLevelAtDefaultLocationRequest);

                    if (stockLevelAtDefaultLocationResponse != null)
                    {
                        int quantityAtDefaultLocation = stockLevelAtDefaultLocationResponse.StockLevel.Available;

                        if (item.IsService)
                        {
                            orderHasServiceItem = true;
                        }

                        if (quantityAtDefaultLocation < item.Quantity)
                        {
                            Logger.WriteInfo("Тhere is no required number of items in default location.");

                            orderCanMoveToDefaultLocation = false;
                            break;
                        }

                        if (item.IsUnlinked)
                        {
                            Logger.WriteInfo("Order has unlinked item.");

                            orderCanMoveToDefaultLocation = false;
                            break;
                        }
                    }
                }

                if (orderCanMoveToDefaultLocation)//&& orderHasServiceItem)
                {
                    Logger.WriteInfo($"All order items can relocate");

                    MoveOrderToLocation(orderId, defaultLocationGuid);
                }
                else Logger.WriteInfo($"Order CANT relocate");
            }
            else Logger.WriteWarning($"Order is null or empty");
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

        private void MoveOrderToLocation(Guid orderGuid, Guid locationGuid)
        {
            try
            {
                List<Guid> orders = new List<Guid> { orderGuid };

                Api.Orders.MoveToLocation(orders, locationGuid);

                Logger.WriteInfo("Relocated to new location");
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Cant relocate order. Error -> {ex}");
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

        private List<InventoryStockLocation> GetAllStockLocations()
        {
            try
            {
                return Api.Inventory.GetStockLocations();
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get stock locations. Error -> {ex}");
                return null;
            }
        }

        private GetStockLevelByLocationResponse GetStockLevelByLocation(GetStockLevelByLocationRequest request)
        {
            try
            {
                return Api.Stock.GetStockLevelByLocation(request);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Can't get stock level of {request.StockItemId} on {request.LocationId}. Error -> {ex}");
                return null;
            }
        }
    }
}