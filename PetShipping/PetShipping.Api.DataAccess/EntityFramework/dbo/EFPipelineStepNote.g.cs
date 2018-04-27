using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepNote", Schema="dbo")]
	public partial class EFPipelineStepNote: AbstractEntityFrameworkPOCO
	{
		public EFPipelineStepNote()
		{}

		public void SetProperties(
			int id,
			int employeeId,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Note = note.ToString();
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
		public virtual EFEmployee Employee { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual EFPipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>1d9fc0e54f8d1c1283f37d175c1656b6</Hash>
</Codenesium>*/