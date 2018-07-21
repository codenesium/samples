using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostHistoryTypesModelMapper
        {
                ApiPostHistoryTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryTypesRequestModel request);

                ApiPostHistoryTypesRequestModel MapResponseToRequest(
                        ApiPostHistoryTypesResponseModel response);

                JsonPatchDocument<ApiPostHistoryTypesRequestModel> CreatePatch(ApiPostHistoryTypesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>466e0d7f4a90acdc0c7fe0ef551472db</Hash>
</Codenesium>*/