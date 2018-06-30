using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiOrganizationModelMapper
        {
                ApiOrganizationResponseModel MapRequestToResponse(
                        int id,
                        ApiOrganizationRequestModel request);

                ApiOrganizationRequestModel MapResponseToRequest(
                        ApiOrganizationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>79915fde034e4e6da03135eb19627d50</Hash>
</Codenesium>*/