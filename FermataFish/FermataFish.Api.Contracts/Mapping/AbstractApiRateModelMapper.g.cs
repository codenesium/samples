using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiRateModelMapper
        {
                public virtual ApiRateResponseModel MapRequestToResponse(
                        int id,
                        ApiRateRequestModel request)
                {
                        var response = new ApiRateResponseModel();
                        response.SetProperties(id,
                                               request.AmountPerMinute,
                                               request.TeacherId,
                                               request.TeacherSkillId);
                        return response;
                }

                public virtual ApiRateRequestModel MapResponseToRequest(
                        ApiRateResponseModel response)
                {
                        var request = new ApiRateRequestModel();
                        request.SetProperties(
                                response.AmountPerMinute,
                                response.TeacherId,
                                response.TeacherSkillId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8fa96da79a281a2c88e3399b593da6ae</Hash>
</Codenesium>*/