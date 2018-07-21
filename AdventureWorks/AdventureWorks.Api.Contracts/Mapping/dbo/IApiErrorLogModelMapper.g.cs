using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiErrorLogModelMapper
        {
                ApiErrorLogResponseModel MapRequestToResponse(
                        int errorLogID,
                        ApiErrorLogRequestModel request);

                ApiErrorLogRequestModel MapResponseToRequest(
                        ApiErrorLogResponseModel response);

                JsonPatchDocument<ApiErrorLogRequestModel> CreatePatch(ApiErrorLogRequestModel model);
        }
}

/*<Codenesium>
    <Hash>215050c95ae2bf5d5805698e5e7db1e9</Hash>
</Codenesium>*/