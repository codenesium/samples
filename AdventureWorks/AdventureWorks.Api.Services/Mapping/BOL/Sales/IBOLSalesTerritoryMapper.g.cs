using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>85951605755c97962847985c76b63818</Hash>
</Codenesium>*/