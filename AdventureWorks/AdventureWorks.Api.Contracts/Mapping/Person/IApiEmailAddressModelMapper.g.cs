using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmailAddressModelMapper
        {
                ApiEmailAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmailAddressRequestModel request);

                ApiEmailAddressRequestModel MapResponseToRequest(
                        ApiEmailAddressResponseModel response);

                JsonPatchDocument<ApiEmailAddressRequestModel> CreatePatch(ApiEmailAddressRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5305a5345fe3d5db903d277b0d523fce</Hash>
</Codenesium>*/