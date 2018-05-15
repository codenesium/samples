using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepNote", Schema="dbo")]
	public partial class PipelineStepNote: AbstractEntityFrameworkPOCO
	{
		public PipelineStepNote()
		{}

		public void SetProperties(
			int id,
			int employeeId,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Note = note;
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("employeeId", TypeName="int")]
		public int EmployeeId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("note", TypeName="text(2147483647)")]
		public string Note { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee Employee { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>b2b24e384c0f7492cd451e0fe21a2ebd</Hash>
</Codenesium>*/