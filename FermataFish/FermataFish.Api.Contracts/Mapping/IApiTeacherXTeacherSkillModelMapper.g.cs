using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherXTeacherSkillModelMapper
        {
                ApiTeacherXTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel request);

                ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherXTeacherSkillResponseModel response);

                JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> CreatePatch(ApiTeacherXTeacherSkillRequestModel model);
        }
}

/*<Codenesium>
    <Hash>783ee4aa86f7d07102e71980df4bd48b</Hash>
</Codenesium>*/