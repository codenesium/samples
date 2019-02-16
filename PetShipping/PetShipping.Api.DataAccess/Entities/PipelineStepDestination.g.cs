using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepDestination", Schema="dbo")]
	public partial class PipelineStepDestination : AbstractEntity
	{
		public PipelineStepDestination()
		{
		}

		public virtual void SetProperties(
			int id,
			int destinationId,
			int pipelineStepId)
		{
			this.Id = id;
			this.DestinationId = destinationId;
			this.PipelineStepId = pipelineStepId;
		}

		[Column("destinationId")]
		public virtual int DestinationId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[ForeignKey("DestinationId")]
		public virtual Destination DestinationIdNavigation { get; private set; }

		public void SetDestinationIdNavigation(Destination item)
		{
			this.DestinationIdNavigation = item;
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
    <Hash>10fa42ebe108974ec824eb2513efd4d7</Hash>
</Codenesium>*/