using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesTerritoryHistoryMapper
        {
                BOSalesTerritoryHistory MapModelToBO(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel model);

                ApiSalesTerritoryHistoryResponseModel MapBOToModel(
                        BOSalesTerritoryHistory boSalesTerritoryHistory);

                List<ApiSalesTerritoryHistoryResponseModel> MapBOToModel(
                        List<BOSalesTerritoryHistory> items);
        }
}

/*<Codenesium>
    <Hash>4530752f6cde86b383b198f7fa802537</Hash>
</Codenesium>*/