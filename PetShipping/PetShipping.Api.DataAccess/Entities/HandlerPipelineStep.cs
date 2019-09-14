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
			int id,
			int handlerId,
			int pipelineStepId)
		{
			this.Id = id;
			this.HandlerId = handlerId;
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
		public virtual Handler HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(Handler item)
		{
			this.HandlerIdNavigation = item;
		}

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(PipelineStep item)
		{
			this.PipelineStepIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>11c7a29f559484fe8e84bc90abf9ee54</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/