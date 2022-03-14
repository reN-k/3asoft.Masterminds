//using LinnworksAPI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace LinnworksMacro
//{
//    public class LinnworksMacro : LinnworksMacroHelpers.LinnworksMacroBase
//    {
//        public void Execute()
//        {
//            Logger.WriteInfo("Start my test macro");            
//            MyTestMacro1();
//            Logger.WriteInfo("End my test macro");            
//        }

//        private void MyTestMacro1()
//        {
//            var locationName = "XYZ";
//            var locationGuid = GetLocationGuidUsingName(locationName);

//            List<BooleanFieldFilter> boolFieldsFilters = new List<BooleanFieldFilter>()
//            {
//                new BooleanFieldFilter()
//                {
//                    FieldCode = FieldCode.GENERAL_INFO_PARKED,
//                    Value = false,
//                },
//                new BooleanFieldFilter()
//                {
//                    FieldCode = FieldCode.GENERAL_INFO_LOCKED,
//                    Value = false,
//                }
//            };            
//            var fieldsFilter = new FieldsFilter()
//            {
//                BooleanFields = boolFieldsFilters,
//            };

//            List<FieldSorting> fieldSortings = new List<FieldSorting>()
//            {
//                new FieldSorting()
//                {
//                    FieldCode = FieldCode.GENERAL_INFO_DATE,
//                    Direction = 0 // ASC
//                }
//            };

//            var openOrdersAtLocation = Api.Orders.GetAllOpenOrders(fieldsFilter, fieldSortings, locationGuid, "");

//            Logger.WriteInfo($"Founded {openOrdersAtLocation.Count} orders.");

//            foreach (var orderId in openOrdersAtLocation)
//            {
//                CheckOrderItems(orderId);
//            }
//        }

//        private Guid GetLocationGuidUsingName(string locationName)
//        {
//            var allLocations = Api.Inventory.GetStockLocations();

//            foreach (var location in allLocations)
//            {
//                var locationGuid = allLocations.Where(loca => loca.LocationName == locationName).FirstOrDefault().StockLocationId;
//                return locationGuid;
//            }

//            Logger.WriteError($"No locations with {locationName} founded.");
//            return new Guid();
//        }

//        private void CheckOrderItems(Guid orderId)
//        {
//            var order = Api.Orders.GetOrderById(orderId);
//            var orderItems = order.Items;
//            bool orderCanMoveToDefaultLocation = true;
//            bool orderHasServiceItem = false;

//            var defaultLocationGuid = GetLocationGuidUsingName("Default");

//            Logger.WriteInfo($"Work with order # {order.NumOrderId}:");

//            foreach (var item in orderItems)
//            {
//                GetStockLevelByLocationRequest stockLevelAtDefaultLocationRequest = new GetStockLevelByLocationRequest()
//                {
//                    LocationId = defaultLocationGuid,
//                    StockItemId = item.StockItemId
//                };
//                var stockLevelAtDefaultLocationResponse = Api.Stock.GetStockLevelByLocation(stockLevelAtDefaultLocationRequest);

//                int quantityAtDefaultLocation = stockLevelAtDefaultLocationResponse.StockLevel.Available;

//                if (item.IsService)
//                {
//                    orderHasServiceItem = true;
//                }

//                if (quantityAtDefaultLocation < item.Quantity)
//                {
//                    Logger.WriteInfo("Тhere is no required number of items in default location.");

//                    orderCanMoveToDefaultLocation = false;
//                    break;
//                }

//                if (item.IsUnlinked)
//                {
//                    Logger.WriteInfo("Order has unlinked item.");

//                    orderCanMoveToDefaultLocation = false;
//                    break;
//                }

//            }


//            if (orderCanMoveToDefaultLocation )//&& orderHasServiceItem)
//            {
//                Logger.WriteInfo($"All order items can relocate");

//                List<Guid> orders = new List<Guid> { orderId };

//                Api.Orders.MoveToLocation(orders, defaultLocationGuid);

//                Logger.WriteInfo("Relocated to default");
//            }
//            else
//            {
//                Logger.WriteInfo($"Order CANT relocate");
//            }
//        }
//    }
//}