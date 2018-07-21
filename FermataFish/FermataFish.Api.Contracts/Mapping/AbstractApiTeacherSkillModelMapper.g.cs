using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherSkillModelMapper
        {
                public virtual ApiTeacherSkillResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherSkillRequestModel request)
                {
                        var response = new ApiTeacherSkillResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiTeacherSkillRequestModel MapResponseToRequest(
                        ApiTeacherSkillResponseModel response)
                {
                        var request = new ApiTeacherSkillRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.StudioId);
                        return request;
                }

                public JsonPatchDocument<ApiTeacherSkillRequestModel> CreatePatch(ApiTeacherSkillRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTeacherSkillRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>6bd593649126b8187be0b4501c89f818</Hash>
</Codenesium>*/