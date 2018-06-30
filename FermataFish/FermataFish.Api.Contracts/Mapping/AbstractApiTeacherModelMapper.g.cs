using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherModelMapper
        {
                public virtual ApiTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherRequestModel request)
                {
                        var response = new ApiTeacherResponseModel();
                        response.SetProperties(id,
                                               request.Birthday,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Phone,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiTeacherRequestModel MapResponseToRequest(
                        ApiTeacherResponseModel response)
                {
                        var request = new ApiTeacherRequestModel();
                        request.SetProperties(
                                response.Birthday,
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Phone,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7e5ff0cf09ff54ea2fccd21d35ec7661</Hash>
</Codenesium>*/