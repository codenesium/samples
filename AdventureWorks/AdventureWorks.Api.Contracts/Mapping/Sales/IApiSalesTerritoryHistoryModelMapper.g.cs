using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTerritoryHistoryModelMapper
        {
                ApiSalesTerritoryHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel request);

                ApiSalesTerritoryHistoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryHistoryResponseModel response);

                JsonPatchDocument<ApiSalesTerritoryHistoryRequestModel> CreatePatch(ApiSalesTerritoryHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ce58b6a4a674ff95a894bbebdcb8cbae</Hash>
</Codenesium>*/