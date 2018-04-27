using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepDestination", Schema="dbo")]
	public partial class EFPipelineStepDestination: AbstractEntityFrameworkPOCO
	{
		public EFPipelineStepDestination()
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
		public virtual EFDestination Destination { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual EFPipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>e519f72a820a96689898eb13770b762c</Hash>
</Codenesium>*/