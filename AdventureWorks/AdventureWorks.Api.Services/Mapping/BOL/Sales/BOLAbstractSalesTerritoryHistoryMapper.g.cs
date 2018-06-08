using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesTerritoryHistoryMapper
        {
                public virtual BOSalesTerritoryHistory MapModelToBO(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel model
                        )
                {
                        BOSalesTerritoryHistory boSalesTerritoryHistory = new BOSalesTerritoryHistory();

                        boSalesTerritoryHistory.SetProperties(
                                businessEntityID,
                                model.EndDate,
                                model.ModifiedDate,
                                model.Rowguid,
                                model.StartDate,
                                model.TerritoryID);
                        return boSalesTerritoryHistory;
                }

                public virtual ApiSalesTerritoryHistoryResponseModel MapBOToModel(
                        BOSalesTerritoryHistory boSalesTerritoryHistory)
                {
                        var model = new ApiSalesTerritoryHistoryResponseModel();

                        model.SetProperties(boSalesTerritoryHistory.BusinessEntityID, boSalesTerritoryHistory.EndDate, boSalesTerritoryHistory.ModifiedDate, boSalesTerritoryHistory.Rowguid, boSalesTerritoryHistory.StartDate, boSalesTerritoryHistory.TerritoryID);

                        return model;
                }

                public virtual List<ApiSalesTerritoryHistoryResponseModel> MapBOToModel(
                        List<BOSalesTerritoryHistory> items)
                {
                        List<ApiSalesTerritoryHistoryResponseModel> response = new List<ApiSalesTerritoryHistoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f630a9c99fa944a3c99fe6f59ee4e97b</Hash>
</Codenesium>*/