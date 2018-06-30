using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTerritoryHistoryModelMapper
        {
                ApiSalesTerritoryHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel request);

                ApiSalesTerritoryHistoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>09307f73d2cdc3ab49af1c23883fef50</Hash>
</Codenesium>*/