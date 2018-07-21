using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTerritoryModelMapper
        {
                ApiSalesTerritoryResponseModel MapRequestToResponse(
                        int territoryID,
                        ApiSalesTerritoryRequestModel request);

                ApiSalesTerritoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryResponseModel response);

                JsonPatchDocument<ApiSalesTerritoryRequestModel> CreatePatch(ApiSalesTerritoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>079a2e6564c7ba3626045ff31ce1b8d4</Hash>
</Codenesium>*/