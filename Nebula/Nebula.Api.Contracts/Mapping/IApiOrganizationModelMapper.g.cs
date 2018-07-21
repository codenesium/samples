using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiOrganizationModelMapper
        {
                ApiOrganizationResponseModel MapRequestToResponse(
                        int id,
                        ApiOrganizationRequestModel request);

                ApiOrganizationRequestModel MapResponseToRequest(
                        ApiOrganizationResponseModel response);

                JsonPatchDocument<ApiOrganizationRequestModel> CreatePatch(ApiOrganizationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>88f11955f5aada1ee26b674d4ee0764e</Hash>
</Codenesium>*/