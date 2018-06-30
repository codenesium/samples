using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStudentModelMapper
        {
                public virtual ApiStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentRequestModel request)
                {
                        var response = new ApiStudentResponseModel();
                        response.SetProperties(id,
                                               request.Birthday,
                                               request.Email,
                                               request.EmailRemindersEnabled,
                                               request.FamilyId,
                                               request.FirstName,
                                               request.IsAdult,
                                               request.LastName,
                                               request.Phone,
                                               request.SmsRemindersEnabled,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiStudentRequestModel MapResponseToRequest(
                        ApiStudentResponseModel response)
                {
                        var request = new ApiStudentRequestModel();
                        request.SetProperties(
                                response.Birthday,
                                response.Email,
                                response.EmailRemindersEnabled,
                                response.FamilyId,
                                response.FirstName,
                                response.IsAdult,
                                response.LastName,
                                response.Phone,
                                response.SmsRemindersEnabled,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>87688ccd1728031a3670a9967bafb6bc</Hash>
</Codenesium>*/