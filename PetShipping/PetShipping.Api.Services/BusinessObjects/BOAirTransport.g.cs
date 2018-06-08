using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOAirTransport: AbstractBusinessObject
        {
                public BOAirTransport() : base()
                {
                }

                public void SetProperties(int airlineId,
                                          string flightNumber,
                                          int handlerId,
                                          int id,
                                          DateTime landDate,
                                          int pipelineStepId,
                                          DateTime takeoffDate)
                {
                        this.AirlineId = airlineId;
                        this.FlightNumber = flightNumber;
                        this.HandlerId = handlerId;
                        this.Id = id;
                        this.LandDate = landDate;
                        this.PipelineStepId = pipelineStepId;
                        this.TakeoffDate = takeoffDate;
                }

                public int AirlineId { get; private set; }

                public string FlightNumber { get; private set; }

                public int HandlerId { get; private set; }

                public int Id { get; private set; }

                public DateTime LandDate { get; private set; }

                public int PipelineStepId { get; private set; }

                public DateTime TakeoffDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b410b45bfb07e2eaae49c633879c7a7c</Hash>
</Codenesium>*/