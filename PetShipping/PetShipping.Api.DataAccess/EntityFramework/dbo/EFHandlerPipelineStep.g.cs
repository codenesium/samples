using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("HandlerPipelineStep", Schema="dbo")]
	public partial class EFHandlerPipelineStep: AbstractEntityFrameworkPOCO
	{
		public EFHandlerPipelineStep()
		{}

		public void SetProperties(
			int id,
			int handlerId,
			int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("handlerId", TypeName="int")]
		public int HandlerId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[ForeignKey("HandlerId")]
		public virtual EFHandler Handler { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual EFPipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>73dc195741386b847c3d95a3654d6574</Hash>
</Codenesium>*/