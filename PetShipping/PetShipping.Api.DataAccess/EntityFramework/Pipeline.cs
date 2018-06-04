using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pipeline", Schema="dbo")]
	public partial class Pipeline: AbstractEntity
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
		public int Id { get; private set; }

		[Column("pipelineStatusId", TypeName="int")]
		public int PipelineStatusId { get; private set; }

		[Column("saleId", TypeName="int")]
		public int SaleId { get; private set; }

		[ForeignKey("PipelineStatusId")]
		public virtual PipelineStatus PipelineStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>0ee1c8c8497e47aeff208436c415d467</Hash>
</Codenesium>*/