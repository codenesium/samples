using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStep", Schema="dbo")]
	public partial class PipelineStep : AbstractEntity
	{
		public PipelineStep()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id;
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId;
			this.ShipperId = shipperId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("pipelineStepStatusId")]
		public int PipelineStepStatusId { get; private set; }

		[Column("shipperId")]
		public int ShipperId { get; private set; }

		[ForeignKey("PipelineStepStatusId")]
		public virtual PipelineStepStatu PipelineStepStatuNavigation { get; private set; }

		[ForeignKey("ShipperId")]
		public virtual Employee EmployeeNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>473ec0b48afbdc780523e5071e8c1d49</Hash>
</Codenesium>*/