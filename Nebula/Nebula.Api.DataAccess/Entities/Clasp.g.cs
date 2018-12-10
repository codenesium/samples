using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("Clasp", Schema="dbo")]
	public partial class Clasp : AbstractEntity
	{
		public Clasp()
		{
		}

		public virtual void SetProperties(
			int id,
			int nextChainId,
			int previousChainId)
		{
			this.Id = id;
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("nextChainId")]
		public virtual int NextChainId { get; private set; }

		[Column("previousChainId")]
		public virtual int PreviousChainId { get; private set; }

		[ForeignKey("NextChainId")]
		public virtual Chain ChainNavigation { get; private set; }

		public void SetChainNavigation(Chain item)
		{
			this.ChainNavigation = item;
		}

		[ForeignKey("PreviousChainId")]
		public virtual Chain Chain1Navigation { get; private set; }

		public void SetChain1Navigation(Chain item)
		{
			this.Chain1Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>8b2fc6755e70da8c65de3109bd41fed2</Hash>
</Codenesium>*/