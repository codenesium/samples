using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("AirTransport", Schema="dbo")]
	public partial class AirTransport : AbstractEntity
	{
		public AirTransport()
		{
		}

		public virtual void SetProperties(
			int id,
			int airlineId,
			string flightNumber,
			int handlerId,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.Id = id;
			this.AirlineId = airlineId;
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;
		}

		[Column("airlineId")]
		public virtual int AirlineId { get; private set; }

		[MaxLength(12)]
		[Column("flightNumber")]
		public virtual string FlightNumber { get; private set; }

		[Column("handlerId")]
		public virtual int HandlerId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("landDate")]
		public virtual DateTime LandDate { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[Column("takeoffDate")]
		public virtual DateTime TakeoffDate { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(Handler item)
		{
			this.HandlerIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>cde001cb481917796cd7e6accfb90ea2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/