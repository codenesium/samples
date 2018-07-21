using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiTimestampCheckModelMapper
        {
                ApiTimestampCheckResponseModel MapRequestToResponse(
                        int id,
                        ApiTimestampCheckRequestModel request);

                ApiTimestampCheckRequestModel MapResponseToRequest(
                        ApiTimestampCheckResponseModel response);

                JsonPatchDocument<ApiTimestampCheckRequestModel> CreatePatch(ApiTimestampCheckRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f1094b8f07711cabbd82f9bdad4704bd</Hash>
</Codenesium>*/