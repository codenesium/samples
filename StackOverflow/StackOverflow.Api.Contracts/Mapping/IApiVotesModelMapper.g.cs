using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiVotesModelMapper
        {
                ApiVotesResponseModel MapRequestToResponse(
                        int id,
                        ApiVotesRequestModel request);

                ApiVotesRequestModel MapResponseToRequest(
                        ApiVotesResponseModel response);

                JsonPatchDocument<ApiVotesRequestModel> CreatePatch(ApiVotesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3ca4b94e1b915254697cb3331da741fa</Hash>
</Codenesium>*/