using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStep", Schema="dbo")]
	public partial class PipelineStep: AbstractEntity
	{
		public PipelineStep()
		{}

		public void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId.ToInt();
			this.ShipperId = shipperId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("pipelineStepStatusId", TypeName="int")]
		public int PipelineStepStatusId { get; private set; }

		[Column("shipperId", TypeName="int")]
		public int ShipperId { get; private set; }

		[ForeignKey("PipelineStepStatusId")]
		public virtual PipelineStepStatus PipelineStepStatus { get; set; }

		[ForeignKey("ShipperId")]
		public virtual Employee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>a195d7dbe566317e454e153a58f21bd4</Hash>
</Codenesium>*/