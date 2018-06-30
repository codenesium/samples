using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiClientCommunicationModelMapper
        {
                ApiClientCommunicationResponseModel MapRequestToResponse(
                        int id,
                        ApiClientCommunicationRequestModel request);

                ApiClientCommunicationRequestModel MapResponseToRequest(
                        ApiClientCommunicationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a315d959ae5eb6781549daec846692aa</Hash>
</Codenesium>*/