using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOAirTransport: AbstractBusinessObject
	{
		public BOAirTransport() : base()
		{}

		public void SetProperties(int airlineId,
		                          string flightNumber,
		                          int handlerId,
		                          int id,
		                          DateTime landDate,
		                          int pipelineStepId,
		                          DateTime takeoffDate)
		{
			this.AirlineId = airlineId.ToInt();
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.LandDate = landDate.ToDateTime();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.TakeoffDate = takeoffDate.ToDateTime();
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
    <Hash>a7b73dc2eb39dff9a203e45f59a2cf1e</Hash>
</Codenesium>*/