using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherModelMapper
        {
                ApiTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherRequestModel request);

                ApiTeacherRequestModel MapResponseToRequest(
                        ApiTeacherResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f2a475627ee521e19a0ed849d0840224</Hash>
</Codenesium>*/