using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepDestination", Schema="dbo")]
	public partial class PipelineStepDestination: AbstractEntityFrameworkPOCO
	{
		public PipelineStepDestination()
		{}

		public void SetProperties(
			int id,
			int destinationId,
			int pipelineStepId)
		{
			this.DestinationId = destinationId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("destinationId", TypeName="int")]
		public int DestinationId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[ForeignKey("DestinationId")]
		public virtual Destination Destination { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>23198b5314bc30f5e3e8708ad02ad37e</Hash>
</Codenesium>*/