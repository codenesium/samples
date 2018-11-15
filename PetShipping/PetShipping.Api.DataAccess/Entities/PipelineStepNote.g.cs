using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepNote", Schema="dbo")]
	public partial class PipelineStepNote : AbstractEntity
	{
		public PipelineStepNote()
		{
		}

		public virtual void SetProperties(
			int employeeId,
			int id,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Note = note;
			this.PipelineStepId = pipelineStepId;
		}

		[Column("employeeId")]
		public virtual int EmployeeId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("note")]
		public virtual string Note { get; private set; }

		[Column("pipelineStepId")]
		public virtual int PipelineStepId { get; private set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeNavigation { get; private set; }

		public void SetEmployeeNavigation(Employee item)
		{
			this.EmployeeNavigation = item;
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
    <Hash>f959f032258c567862b881f24619bb97</Hash>
</Codenesium>*/