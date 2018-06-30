using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiAirTransportModelMapper
        {
                public virtual ApiAirTransportResponseModel MapRequestToResponse(
                        int airlineId,
                        ApiAirTransportRequestModel request)
                {
                        var response = new ApiAirTransportResponseModel();
                        response.SetProperties(airlineId,
                                               request.FlightNumber,
                                               request.HandlerId,
                                               request.Id,
                                               request.LandDate,
                                               request.PipelineStepId,
                                               request.TakeoffDate);
                        return response;
                }

                public virtual ApiAirTransportRequestModel MapResponseToRequest(
                        ApiAirTransportResponseModel response)
                {
                        var request = new ApiAirTransportRequestModel();
                        request.SetProperties(
                                response.FlightNumber,
                                response.HandlerId,
                                response.Id,
                                response.LandDate,
                                response.PipelineStepId,
                                response.TakeoffDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>dd7459dca77d048230c4d32968817b1d</Hash>
</Codenesium>*/