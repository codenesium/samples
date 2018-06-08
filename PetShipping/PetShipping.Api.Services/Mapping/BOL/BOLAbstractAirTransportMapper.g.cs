using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractAirTransportMapper
        {
                public virtual BOAirTransport MapModelToBO(
                        int airlineId,
                        ApiAirTransportRequestModel model
                        )
                {
                        BOAirTransport boAirTransport = new BOAirTransport();

                        boAirTransport.SetProperties(
                                airlineId,
                                model.FlightNumber,
                                model.HandlerId,
                                model.Id,
                                model.LandDate,
                                model.PipelineStepId,
                                model.TakeoffDate);
                        return boAirTransport;
                }

                public virtual ApiAirTransportResponseModel MapBOToModel(
                        BOAirTransport boAirTransport)
                {
                        var model = new ApiAirTransportResponseModel();

                        model.SetProperties(boAirTransport.AirlineId, boAirTransport.FlightNumber, boAirTransport.HandlerId, boAirTransport.Id, boAirTransport.LandDate, boAirTransport.PipelineStepId, boAirTransport.TakeoffDate);

                        return model;
                }

                public virtual List<ApiAirTransportResponseModel> MapBOToModel(
                        List<BOAirTransport> items)
                {
                        List<ApiAirTransportResponseModel> response = new List<ApiAirTransportResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>628ac8c7fdd28a96fcc119568805a9c6</Hash>
</Codenesium>*/