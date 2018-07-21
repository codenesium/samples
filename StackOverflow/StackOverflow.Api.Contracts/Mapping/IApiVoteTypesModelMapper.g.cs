using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiVoteTypesModelMapper
        {
                ApiVoteTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiVoteTypesRequestModel request);

                ApiVoteTypesRequestModel MapResponseToRequest(
                        ApiVoteTypesResponseModel response);

                JsonPatchDocument<ApiVoteTypesRequestModel> CreatePatch(ApiVoteTypesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>871977840d2947be34a8a65c57f82d6f</Hash>
</Codenesium>*/