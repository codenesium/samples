using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesOrderHeaderSalesReasonMapper
        {
                public virtual BOSalesOrderHeaderSalesReason MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel model
                        )
                {
                        BOSalesOrderHeaderSalesReason boSalesOrderHeaderSalesReason = new BOSalesOrderHeaderSalesReason();
                        boSalesOrderHeaderSalesReason.SetProperties(
                                salesOrderID,
                                model.ModifiedDate,
                                model.SalesReasonID);
                        return boSalesOrderHeaderSalesReason;
                }

                public virtual ApiSalesOrderHeaderSalesReasonResponseModel MapBOToModel(
                        BOSalesOrderHeaderSalesReason boSalesOrderHeaderSalesReason)
                {
                        var model = new ApiSalesOrderHeaderSalesReasonResponseModel();

                        model.SetProperties(boSalesOrderHeaderSalesReason.ModifiedDate, boSalesOrderHeaderSalesReason.SalesOrderID, boSalesOrderHeaderSalesReason.SalesReasonID);

                        return model;
                }

                public virtual List<ApiSalesOrderHeaderSalesReasonResponseModel> MapBOToModel(
                        List<BOSalesOrderHeaderSalesReason> items)
                {
                        List<ApiSalesOrderHeaderSalesReasonResponseModel> response = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>53e0cfdba9a83043316289ca610706ce</Hash>
</Codenesium>*/