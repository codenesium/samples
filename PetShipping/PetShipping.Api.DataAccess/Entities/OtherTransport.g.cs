using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("OtherTransport", Schema="dbo")]
	public partial class OtherTransport : AbstractEntity
	{
		public OtherTransport()
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
    <Hash>0ed00bcd22c2594a9030a6fcfcae1f3d</Hash>
</Codenesium>*/