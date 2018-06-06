using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("HandlerPipelineStep", Schema="dbo")]
	public partial class HandlerPipelineStep: AbstractEntity
	{
		public HandlerPipelineStep()
		{}

		public void SetProperties(
			int handlerId,
			int id,
			int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("handlerId", TypeName="int")]
		public int HandlerId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler Handler { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>291c7c56f842722d33ca315618338dbb</Hash>
</Codenesium>*/