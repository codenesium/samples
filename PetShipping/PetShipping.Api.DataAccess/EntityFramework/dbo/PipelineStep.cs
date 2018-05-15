using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStep", Schema="dbo")]
	public partial class PipelineStep: AbstractEntityFrameworkPOCO
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
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("pipelineStepStatusId", TypeName="int")]
		public int PipelineStepStatusId { get; set; }

		[Column("shipperId", TypeName="int")]
		public int ShipperId { get; set; }

		[ForeignKey("PipelineStepStatusId")]
		public virtual PipelineStepStatus PipelineStepStatus { get; set; }

		[ForeignKey("ShipperId")]
		public virtual Employee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>4bd2a3a5a72062dc50258fff05d24c1b</Hash>
</Codenesium>*/