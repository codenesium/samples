using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPurchaseOrderDetailMapper
        {
                public virtual BOPurchaseOrderDetail MapModelToBO(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel model
                        )
                {
                        BOPurchaseOrderDetail boPurchaseOrderDetail = new BOPurchaseOrderDetail();

                        boPurchaseOrderDetail.SetProperties(
                                purchaseOrderID,
                                model.DueDate,
                                model.LineTotal,
                                model.ModifiedDate,
                                model.OrderQty,
                                model.ProductID,
                                model.PurchaseOrderDetailID,
                                model.ReceivedQty,
                                model.RejectedQty,
                                model.StockedQty,
                                model.UnitPrice);
                        return boPurchaseOrderDetail;
                }

                public virtual ApiPurchaseOrderDetailResponseModel MapBOToModel(
                        BOPurchaseOrderDetail boPurchaseOrderDetail)
                {
                        var model = new ApiPurchaseOrderDetailResponseModel();

                        model.SetProperties(boPurchaseOrderDetail.DueDate, boPurchaseOrderDetail.LineTotal, boPurchaseOrderDetail.ModifiedDate, boPurchaseOrderDetail.OrderQty, boPurchaseOrderDetail.ProductID, boPurchaseOrderDetail.PurchaseOrderDetailID, boPurchaseOrderDetail.PurchaseOrderID, boPurchaseOrderDetail.ReceivedQty, boPurchaseOrderDetail.RejectedQty, boPurchaseOrderDetail.StockedQty, boPurchaseOrderDetail.UnitPrice);

                        return model;
                }

                public virtual List<ApiPurchaseOrderDetailResponseModel> MapBOToModel(
                        List<BOPurchaseOrderDetail> items)
                {
                        List<ApiPurchaseOrderDetailResponseModel> response = new List<ApiPurchaseOrderDetailResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b8147090142e4eb2ccb739fd8e12172d</Hash>
</Codenesium>*/