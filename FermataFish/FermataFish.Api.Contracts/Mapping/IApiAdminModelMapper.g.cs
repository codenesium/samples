using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiAdminModelMapper
        {
                ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request);

                ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response);
        }
}

/*<Codenesium>
    <Hash>44720bdf998069ceea3499c538b79def</Hash>
</Codenesium>*/