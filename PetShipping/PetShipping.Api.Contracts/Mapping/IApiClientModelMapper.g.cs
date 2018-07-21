using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiClientModelMapper
        {
                ApiClientResponseModel MapRequestToResponse(
                        int id,
                        ApiClientRequestModel request);

                ApiClientRequestModel MapResponseToRequest(
                        ApiClientResponseModel response);

                JsonPatchDocument<ApiClientRequestModel> CreatePatch(ApiClientRequestModel model);
        }
}

/*<Codenesium>
    <Hash>653fd67e22c6300288356671f249325c</Hash>
</Codenesium>*/