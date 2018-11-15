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
			int airlineId,
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

		[Key]
		[Column("airlineId")]
		public virtual int AirlineId { get; private set; }

		[MaxLength(12)]
		[Column("flightNumber")]
		public virtual string FlightNumber { get; private set; }

		[Column("handlerId")]
		public virtual int HandlerId { get; private set; }

		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("landDate")]
		public virtual DateTime LandDate { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[Column("takeoffDate")]
		public virtual DateTime TakeoffDate { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler HandlerNavigation { get; private set; }

		public void SetHandlerNavigation(Handler item)
		{
			this.HandlerNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>4c9a9776c58611ae3db4144dffcf0d5b</Hash>
</Codenesium>*/