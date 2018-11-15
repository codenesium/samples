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
			string detail,
			int id,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Detail = detail;
			this.Id = id;
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
		public virtual PipelineStep PipelineStepNavigation { get; private set; }

		public void SetPipelineStepNavigation(PipelineStep item)
		{
			this.PipelineStepNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>60b5cce2c29c667acc57bf56c096250b</Hash>
</Codenesium>*/