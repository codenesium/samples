using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("HandlerPipelineStep", Schema="dbo")]
	public partial class HandlerPipelineStep : AbstractEntity
	{
		public HandlerPipelineStep()
		{
		}

		public virtual void SetProperties(
			int handlerId,
			int id,
			int pipelineStepId)
		{
			this.HandlerId = handlerId;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
		}

		[Column("handlerId")]
		public virtual int HandlerId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler HandlerNavigation { get; private set; }

		public void SetHandlerNavigation(Handler item)
		{
			this.HandlerNavigation = item;
		}

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStepNavigation { get; private set; }

		public void SetPipelineStepNavigation(PipelineStep item)
		{
			this.PipelineStepNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b619582c73c1622a18a14b4bf1559abc</Hash>
</Codenesium>*/