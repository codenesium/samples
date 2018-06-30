using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiAdminModelMapper
        {
                public virtual ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request)
                {
                        var response = new ApiAdminResponseModel();
                        response.SetProperties(id,
                                               request.Birthday,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Phone,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response)
                {
                        var request = new ApiAdminRequestModel();
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
    <Hash>d986910209468248b4a72a798d587a9c</Hash>
</Codenesium>*/