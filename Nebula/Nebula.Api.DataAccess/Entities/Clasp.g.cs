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
			int nextChainId,
			int previousChainId)
		{
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;
		}

		[Key]
		[Column("nextChainId")]
		public int NextChainId { get; private set; }

		[Key]
		[Column("previousChainId")]
		public int PreviousChainId { get; private set; }

		[ForeignKey("NextChainId")]
		public virtual Chain ChainNavigation { get; private set; }

		[ForeignKey("PreviousChainId")]
		public virtual Chain Chain1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e195661f7380620028f79fd5f80a81ba</Hash>
</Codenesium>*/