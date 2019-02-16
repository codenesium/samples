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
		public virtual Handler HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(Handler item)
		{
			this.HandlerIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>735b6e14feffa4bc8000aab4e8dfd84b</Hash>
</Codenesium>*/