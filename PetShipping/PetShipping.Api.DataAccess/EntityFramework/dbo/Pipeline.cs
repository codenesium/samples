using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pipeline", Schema="dbo")]
	public partial class Pipeline: AbstractEntityFrameworkPOCO
	{
		public Pipeline()
		{}

		public void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id.ToInt();
			this.PipelineStatusId = pipelineStatusId.ToInt();
			this.SaleId = saleId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pipelineStatusId", TypeName="int")]
		public int PipelineStatusId { get; set; }

		[Column("saleId", TypeName="int")]
		public int SaleId { get; set; }

		[ForeignKey("PipelineStatusId")]
		public virtual PipelineStatus PipelineStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>a982ee140f151c1dd4df033426e9292f</Hash>
</Codenesium>*/