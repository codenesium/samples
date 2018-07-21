using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiSchemaBPersonModelMapper
        {
                ApiSchemaBPersonResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaBPersonRequestModel request);

                ApiSchemaBPersonRequestModel MapResponseToRequest(
                        ApiSchemaBPersonResponseModel response);

                JsonPatchDocument<ApiSchemaBPersonRequestModel> CreatePatch(ApiSchemaBPersonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>919dc3ee1b760d0b4ff1871d310569b7</Hash>
</Codenesium>*/