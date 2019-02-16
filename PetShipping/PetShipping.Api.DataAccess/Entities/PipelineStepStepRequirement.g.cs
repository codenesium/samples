using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepStepRequirement", Schema="dbo")]
	public partial class PipelineStepStepRequirement : AbstractEntity
	{
		public PipelineStepStepRequirement()
		{
		}

		public virtual void SetProperties(
			int id,
			string detail,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Id = id;
			this.Detail = detail;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[MaxLength(2147483647)]
		[Column("details")]
		public virtual string Detail { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[Column("requirementMet")]
		public virtual bool RequirementMet { get; private set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(PipelineStep item)
		{
			this.PipelineStepIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0f9f4079a91ec1a6c547c421f9a69e8c</Hash>
</Codenesium>*/