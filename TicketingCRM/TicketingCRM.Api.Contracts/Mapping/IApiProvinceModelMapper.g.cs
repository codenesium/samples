using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiProvinceModelMapper
        {
                ApiProvinceResponseModel MapRequestToResponse(
                        int id,
                        ApiProvinceRequestModel request);

                ApiProvinceRequestModel MapResponseToRequest(
                        ApiProvinceResponseModel response);

                JsonPatchDocument<ApiProvinceRequestModel> CreatePatch(ApiProvinceRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f660269006e3ac5ec4f11f13f38acb5e</Hash>
</Codenesium>*/