using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepDestination", Schema="dbo")]
	public partial class PipelineStepDestination: AbstractEntity
	{
		public PipelineStepDestination()
		{}

		public void SetProperties(
			int destinationId,
			int id,
			int pipelineStepId)
		{
			this.DestinationId = destinationId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("destinationId", TypeName="int")]
		public int DestinationId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; private set; }

		[ForeignKey("DestinationId")]
		public virtual Destination Destination { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>c959ced48f4d9a15122465912a0865e9</Hash>
</Codenesium>*/