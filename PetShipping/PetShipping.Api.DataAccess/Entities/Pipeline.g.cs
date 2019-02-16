using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pipeline", Schema="dbo")]
	public partial class Pipeline : AbstractEntity
	{
		public Pipeline()
		{
		}

		public virtual void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("pipelineStatusId")]
		public virtual int PipelineStatusId { get; private set; }

		[Column("saleId")]
		public virtual int SaleId { get; private set; }

		[ForeignKey("PipelineStatusId")]
		public virtual PipelineStatu PipelineStatusIdNavigation { get; private set; }

		public void SetPipelineStatusIdNavigation(PipelineStatu item)
		{
			this.PipelineStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ca5c5fe3c1b129ef55c4ddc20fe4a2f9</Hash>
</Codenesium>*/