using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>778d5bcd85e5cdc7d89cb20dfb6f229e</Hash>
</Codenesium>*/