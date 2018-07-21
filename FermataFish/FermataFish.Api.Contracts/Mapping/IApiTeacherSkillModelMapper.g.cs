using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherSkillModelMapper
        {
                ApiTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherSkillRequestModel request);

                ApiTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherSkillResponseModel response);

                JsonPatchDocument<ApiTeacherSkillRequestModel> CreatePatch(ApiTeacherSkillRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e641597911ddc3c39f53916882b2e6a3</Hash>
</Codenesium>*/