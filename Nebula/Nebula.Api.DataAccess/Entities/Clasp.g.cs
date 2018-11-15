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
	}
}

/*<Codenesium>
    <Hash>f9b0f0fb18b40c7d047b42bfaaec86b6</Hash>
</Codenesium>*/