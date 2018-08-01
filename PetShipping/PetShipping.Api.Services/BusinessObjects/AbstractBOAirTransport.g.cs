using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOAirTransport : AbstractBusinessObject
	{
		public AbstractBOAirTransport()
			: base()
		{
		}

		public virtual void SetProperties(int airlineId,
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
    <Hash>6c4638c36a1e96842d157ea3c2d5dc68</Hash>
</Codenesium>*/