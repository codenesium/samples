using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0dc221ec655d97b1d016e70235c0ca7f</Hash>
</Codenesium>*/