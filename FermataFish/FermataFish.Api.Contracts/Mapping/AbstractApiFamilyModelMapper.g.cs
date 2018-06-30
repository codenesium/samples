using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiFamilyModelMapper
        {
                public virtual ApiFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiFamilyRequestModel request)
                {
                        var response = new ApiFamilyResponseModel();
                        response.SetProperties(id,
                                               request.Notes,
                                               request.PcEmail,
                                               request.PcFirstName,
                                               request.PcLastName,
                                               request.PcPhone,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiFamilyRequestModel MapResponseToRequest(
                        ApiFamilyResponseModel response)
                {
                        var request = new ApiFamilyRequestModel();
                        request.SetProperties(
                                response.Notes,
                                response.PcEmail,
                                response.PcFirstName,
                                response.PcLastName,
                                response.PcPhone,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>11adbe9a0ea5b8b799f4db484bf3de51</Hash>
</Codenesium>*/