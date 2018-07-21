using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShipMethodModelMapper
        {
                ApiShipMethodResponseModel MapRequestToResponse(
                        int shipMethodID,
                        ApiShipMethodRequestModel request);

                ApiShipMethodRequestModel MapResponseToRequest(
                        ApiShipMethodResponseModel response);

                JsonPatchDocument<ApiShipMethodRequestModel> CreatePatch(ApiShipMethodRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b121ae1d4aecefef75c230ccdd89a045</Hash>
</Codenesium>*/