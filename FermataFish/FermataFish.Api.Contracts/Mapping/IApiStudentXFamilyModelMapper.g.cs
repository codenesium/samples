using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudentXFamilyModelMapper
        {
                ApiStudentXFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentXFamilyRequestModel request);

                ApiStudentXFamilyRequestModel MapResponseToRequest(
                        ApiStudentXFamilyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0d067536744347c485136e702283782b</Hash>
</Codenesium>*/