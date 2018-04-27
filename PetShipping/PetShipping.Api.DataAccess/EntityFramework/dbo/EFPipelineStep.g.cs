using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStep", Schema="dbo")]
	public partial class EFPipelineStep: AbstractEntityFrameworkPOCO
	{
		public EFPipelineStep()
		{}

		public void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
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
		public virtual EFPipelineStepStatus PipelineStepStatus { get; set; }

		[ForeignKey("ShipperId")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>1d75731b08c1242578c67ed0cbbdf19d</Hash>
</Codenesium>*/