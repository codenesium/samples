using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiTagsModelMapper
        {
                ApiTagsResponseModel MapRequestToResponse(
                        int id,
                        ApiTagsRequestModel request);

                ApiTagsRequestModel MapResponseToRequest(
                        ApiTagsResponseModel response);

                JsonPatchDocument<ApiTagsRequestModel> CreatePatch(ApiTagsRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ba964246077cf938bf9230d734568bf5</Hash>
</Codenesium>*/