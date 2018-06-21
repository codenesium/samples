using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a691f8859ba8a8637c188ce16e11cb34</Hash>
</Codenesium>*/