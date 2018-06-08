using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesTerritoryMapper
        {
                BOSalesTerritory MapModelToBO(
                        int territoryID,
                        ApiSalesTerritoryRequestModel model);

                ApiSalesTerritoryResponseModel MapBOToModel(
                        BOSalesTerritory boSalesTerritory);

                List<ApiSalesTerritoryResponseModel> MapBOToModel(
                        List<BOSalesTerritory> items);
        }
}

/*<Codenesium>
    <Hash>76eb3ebf6857412cf1bf7c78455ea007</Hash>
</Codenesium>*/