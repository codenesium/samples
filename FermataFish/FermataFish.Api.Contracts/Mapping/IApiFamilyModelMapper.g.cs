using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiFamilyModelMapper
        {
                ApiFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiFamilyRequestModel request);

                ApiFamilyRequestModel MapResponseToRequest(
                        ApiFamilyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fa7755bfdd5b838bb08379ff95e4db17</Hash>
</Codenesium>*/