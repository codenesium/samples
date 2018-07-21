using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiTableModelMapper
        {
                ApiTableResponseModel MapRequestToResponse(
                        int id,
                        ApiTableRequestModel request);

                ApiTableRequestModel MapResponseToRequest(
                        ApiTableResponseModel response);

                JsonPatchDocument<ApiTableRequestModel> CreatePatch(ApiTableRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c1e59277f4e9dd4f5c97839633d9fb7c</Hash>
</Codenesium>*/