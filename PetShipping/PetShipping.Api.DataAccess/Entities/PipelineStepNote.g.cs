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
			int id,
			int employeeId,
			string note,
			int pipelineStepId)
		{
			this.Id = id;
			this.EmployeeId = employeeId;
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
		public virtual Employee EmployeeIdNavigation { get; private set; }

		public void SetEmployeeIdNavigation(Employee item)
		{
			this.EmployeeIdNavigation = item;
		}

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(PipelineStep item)
		{
			this.PipelineStepIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>86c090406638bd51a8f75b3e5d26c4a1</Hash>
</Codenesium>*/