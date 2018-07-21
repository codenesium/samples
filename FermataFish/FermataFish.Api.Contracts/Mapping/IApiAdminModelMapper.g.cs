using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiAdminModelMapper
        {
                ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request);

                ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response);

                JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7d052bba4de3346d9743efb5cb515786</Hash>
</Codenesium>*/