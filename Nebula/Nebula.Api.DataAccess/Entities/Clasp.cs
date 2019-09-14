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
		public virtual Chain NextChainIdNavigation { get; private set; }

		public void SetNextChainIdNavigation(Chain item)
		{
			this.NextChainIdNavigation = item;
		}

		[ForeignKey("PreviousChainId")]
		public virtual Chain PreviousChainIdNavigation { get; private set; }

		public void SetPreviousChainIdNavigation(Chain item)
		{
			this.PreviousChainIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e6ce6d8e68e125602e7bad914efa771c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/