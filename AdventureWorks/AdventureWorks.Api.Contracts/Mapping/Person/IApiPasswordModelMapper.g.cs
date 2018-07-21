using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPasswordModelMapper
        {
                ApiPasswordResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPasswordRequestModel request);

                ApiPasswordRequestModel MapResponseToRequest(
                        ApiPasswordResponseModel response);

                JsonPatchDocument<ApiPasswordRequestModel> CreatePatch(ApiPasswordRequestModel model);
        }
}

/*<Codenesium>
    <Hash>efbea00e5d551859e4884b2921e68eac</Hash>
</Codenesium>*/