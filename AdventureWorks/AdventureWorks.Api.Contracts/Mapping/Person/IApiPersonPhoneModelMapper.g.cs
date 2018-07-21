using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonPhoneModelMapper
        {
                ApiPersonPhoneResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel request);

                ApiPersonPhoneRequestModel MapResponseToRequest(
                        ApiPersonPhoneResponseModel response);

                JsonPatchDocument<ApiPersonPhoneRequestModel> CreatePatch(ApiPersonPhoneRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d8a3c515145b028c2a28e984eca15adf</Hash>
</Codenesium>*/