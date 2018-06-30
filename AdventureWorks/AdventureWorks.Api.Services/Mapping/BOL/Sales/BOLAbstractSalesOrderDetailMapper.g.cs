using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesOrderDetailMapper
        {
                public virtual BOSalesOrderDetail MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel model
                        )
                {
                        BOSalesOrderDetail boSalesOrderDetail = new BOSalesOrderDetail();
                        boSalesOrderDetail.SetProperties(
                                salesOrderID,
                                model.CarrierTrackingNumber,
                                model.LineTotal,
                                model.ModifiedDate,
                                model.OrderQty,
                                model.ProductID,
                                model.Rowguid,
                                model.SalesOrderDetailID,
                                model.SpecialOfferID,
                                model.UnitPrice,
                                model.UnitPriceDiscount);
                        return boSalesOrderDetail;
                }

                public virtual ApiSalesOrderDetailResponseModel MapBOToModel(
                        BOSalesOrderDetail boSalesOrderDetail)
                {
                        var model = new ApiSalesOrderDetailResponseModel();

                        model.SetProperties(boSalesOrderDetail.SalesOrderID, boSalesOrderDetail.CarrierTrackingNumber, boSalesOrderDetail.LineTotal, boSalesOrderDetail.ModifiedDate, boSalesOrderDetail.OrderQty, boSalesOrderDetail.ProductID, boSalesOrderDetail.Rowguid, boSalesOrderDetail.SalesOrderDetailID, boSalesOrderDetail.SpecialOfferID, boSalesOrderDetail.UnitPrice, boSalesOrderDetail.UnitPriceDiscount);

                        return model;
                }

                public virtual List<ApiSalesOrderDetailResponseModel> MapBOToModel(
                        List<BOSalesOrderDetail> items)
                {
                        List<ApiSalesOrderDetailResponseModel> response = new List<ApiSalesOrderDetailResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6a86d8df86e0500d21c667569c8e0f14</Hash>
</Codenesium>*/