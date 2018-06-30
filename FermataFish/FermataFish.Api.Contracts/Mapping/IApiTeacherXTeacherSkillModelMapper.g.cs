using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherXTeacherSkillModelMapper
        {
                ApiTeacherXTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel request);

                ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherXTeacherSkillResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e28fd51769ba6504e9d2ee7784e7dac3</Hash>
</Codenesium>*/