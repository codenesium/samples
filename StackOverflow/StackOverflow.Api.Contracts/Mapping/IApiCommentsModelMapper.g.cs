using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiCommentsModelMapper
        {
                ApiCommentsResponseModel MapRequestToResponse(
                        int id,
                        ApiCommentsRequestModel request);

                ApiCommentsRequestModel MapResponseToRequest(
                        ApiCommentsResponseModel response);

                JsonPatchDocument<ApiCommentsRequestModel> CreatePatch(ApiCommentsRequestModel model);
        }
}

/*<Codenesium>
    <Hash>81eb40ad4915806bfa9ab2df86f15dcf</Hash>
</Codenesium>*/