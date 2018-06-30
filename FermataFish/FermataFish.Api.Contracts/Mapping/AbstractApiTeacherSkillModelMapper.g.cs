using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>6071b87f12ddd895df661eb041cf1fd8</Hash>
</Codenesium>*/