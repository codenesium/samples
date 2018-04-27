using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("AirTransport", Schema="dbo")]
	public partial class EFAirTransport: AbstractEntityFrameworkPOCO
	{
		public EFAirTransport()
		{}

		public void SetProperties(
			int airlineId,
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.AirlineId = airlineId.ToInt();
			this.FlightNumber = flightNumber.ToString();
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.LandDate = landDate.ToDateTime();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.TakeoffDate = takeoffDate.ToDateTime();
		}

		[Key]
		[Column("airlineId", TypeName="int")]
		public int AirlineId { get; set; }

		[Column("flightNumber", TypeName="varchar(12)")]
		public string FlightNumber { get; set; }

		[Column("handlerId", TypeName="int")]
		public int HandlerId { get; set; }

		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("landDate", TypeName="datetime")]
		public DateTime LandDate { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[Column("takeoffDate", TypeName="datetime")]
		public DateTime TakeoffDate { get; set; }

		[ForeignKey("HandlerId")]
		public virtual EFHandler Handler { get; set; }
	}
}

/*<Codenesium>
    <Hash>1d22f1d9f37f4eddcb82aeaa9586b1b0</Hash>
</Codenesium>*/