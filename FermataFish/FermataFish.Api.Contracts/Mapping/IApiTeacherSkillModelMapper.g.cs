using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherSkillModelMapper
        {
                ApiTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherSkillRequestModel request);

                ApiTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherSkillResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0057b5d475c2eeccf5a85894d669dc7e</Hash>
</Codenesium>*/