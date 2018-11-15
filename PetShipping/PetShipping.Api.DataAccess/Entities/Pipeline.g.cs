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
		public virtual PipelineStatu PipelineStatuNavigation { get; private set; }

		public void SetPipelineStatuNavigation(PipelineStatu item)
		{
			this.PipelineStatuNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>4cf99a5b3d6a89d344a07c7a1de81c91</Hash>
</Codenesium>*/