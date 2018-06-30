using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiClientCommunicationModelMapper
        {
                public virtual ApiClientCommunicationResponseModel MapRequestToResponse(
                        int id,
                        ApiClientCommunicationRequestModel request)
                {
                        var response = new ApiClientCommunicationResponseModel();
                        response.SetProperties(id,
                                               request.ClientId,
                                               request.DateCreated,
                                               request.EmployeeId,
                                               request.Notes);
                        return response;
                }

                public virtual ApiClientCommunicationRequestModel MapResponseToRequest(
                        ApiClientCommunicationResponseModel response)
                {
                        var request = new ApiClientCommunicationRequestModel();
                        request.SetProperties(
                                response.ClientId,
                                response.DateCreated,
                                response.EmployeeId,
                                response.Notes);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>93566f590356fcb4d4e24431a011e5c8</Hash>
</Codenesium>*/