using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOAirTransport: AbstractDTO
	{
		public DTOAirTransport() : base()
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

		public int AirlineId { get; set; }
		public string FlightNumber { get; set; }
		public int HandlerId { get; set; }
		public int Id { get; set; }
		public DateTime LandDate { get; set; }
		public int PipelineStepId { get; set; }
		public DateTime TakeoffDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>ba670803db13f2b88f20dc57b646d440</Hash>
</Codenesium>*/