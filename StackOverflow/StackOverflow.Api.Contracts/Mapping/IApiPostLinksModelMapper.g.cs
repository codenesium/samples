using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostLinksModelMapper
        {
                ApiPostLinksResponseModel MapRequestToResponse(
                        int id,
                        ApiPostLinksRequestModel request);

                ApiPostLinksRequestModel MapResponseToRequest(
                        ApiPostLinksResponseModel response);

                JsonPatchDocument<ApiPostLinksRequestModel> CreatePatch(ApiPostLinksRequestModel model);
        }
}

/*<Codenesium>
    <Hash>118432dd2689eef2219dc74b6ed2bae6</Hash>
</Codenesium>*/