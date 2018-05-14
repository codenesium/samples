using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("OtherTransport", Schema="dbo")]
	public partial class OtherTransport: AbstractEntityFrameworkPOCO
	{
		public OtherTransport()
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
		public virtual Handler Handler { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>a04ac8278d6d9b0eac6d4ebcb49dd909</Hash>
</Codenesium>*/