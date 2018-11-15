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
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("pipelineStepStatusId")]
		public virtual int PipelineStepStatusId { get; private set; }

		[Column("shipperId")]
		public virtual int ShipperId { get; private set; }

		[ForeignKey("PipelineStepStatusId")]
		public virtual PipelineStepStatu PipelineStepStatuNavigation { get; private set; }

		public void SetPipelineStepStatuNavigation(PipelineStepStatu item)
		{
			this.PipelineStepStatuNavigation = item;
		}

		[ForeignKey("ShipperId")]
		public virtual Employee EmployeeNavigation { get; private set; }

		public void SetEmployeeNavigation(Employee item)
		{
			this.EmployeeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>923ee8f49980fcd6b6e92c5854787bbb</Hash>
</Codenesium>*/