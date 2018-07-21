using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostHistoryModelMapper
        {
                ApiPostHistoryResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryRequestModel request);

                ApiPostHistoryRequestModel MapResponseToRequest(
                        ApiPostHistoryResponseModel response);

                JsonPatchDocument<ApiPostHistoryRequestModel> CreatePatch(ApiPostHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>eecb6a76ab997a867ce4fd6794938982</Hash>
</Codenesium>*/