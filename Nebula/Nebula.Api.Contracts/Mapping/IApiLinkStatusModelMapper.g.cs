using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkStatusModelMapper
        {
                ApiLinkStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkStatusRequestModel request);

                ApiLinkStatusRequestModel MapResponseToRequest(
                        ApiLinkStatusResponseModel response);

                JsonPatchDocument<ApiLinkStatusRequestModel> CreatePatch(ApiLinkStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>aec1dce900643a6704620410eff9aa3a</Hash>
</Codenesium>*/