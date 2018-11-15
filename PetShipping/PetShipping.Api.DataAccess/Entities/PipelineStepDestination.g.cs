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
			int destinationId,
			int id,
			int pipelineStepId)
		{
			this.DestinationId = destinationId;
			this.Id = id;
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
		public virtual Destination DestinationNavigation { get; private set; }

		public void SetDestinationNavigation(Destination item)
		{
			this.DestinationNavigation = item;
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
    <Hash>4cb0a51a973b8dae9e07c197f35caafd</Hash>
</Codenesium>*/