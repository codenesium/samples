using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherXTeacherSkillModelMapper
        {
                public virtual ApiTeacherXTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel request)
                {
                        var response = new ApiTeacherXTeacherSkillResponseModel();
                        response.SetProperties(id,
                                               request.TeacherId,
                                               request.TeacherSkillId);
                        return response;
                }

                public virtual ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherXTeacherSkillResponseModel response)
                {
                        var request = new ApiTeacherXTeacherSkillRequestModel();
                        request.SetProperties(
                                response.TeacherId,
                                response.TeacherSkillId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f686f7c4e129c9c1cadd549b307a002c</Hash>
</Codenesium>*/