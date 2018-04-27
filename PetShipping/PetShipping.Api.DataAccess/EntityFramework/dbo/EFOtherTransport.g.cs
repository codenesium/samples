using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("OtherTransport", Schema="dbo")]
	public partial class EFOtherTransport: AbstractEntityFrameworkPOCO
	{
		public EFOtherTransport()
		{}

		public void SetProperties(
			int id,
			int handlerId,
			int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		[Column("handlerId", TypeName="int")]
		public int HandlerId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[ForeignKey("HandlerId")]
		public virtual EFHandler Handler { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual EFPipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>fe138c6a5b5f87f93dfe8b2968352bfd</Hash>
</Codenesium>*/