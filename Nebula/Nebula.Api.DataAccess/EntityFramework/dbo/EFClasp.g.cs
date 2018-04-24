using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Clasp", Schema="dbo")]
	public partial class EFClasp: AbstractEntityFrameworkPOCO
	{
		public EFClasp()
		{}

		public void SetProperties(
			int id,
			int previousChainId,
			int nextChainId)
		{
			this.Id = id.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
			this.NextChainId = nextChainId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("previousChainId", TypeName="int")]
		public int PreviousChainId { get; set; }

		[Column("nextChainId", TypeName="int")]
		public int NextChainId { get; set; }

		[ForeignKey("PreviousChainId")]
		public virtual EFChain Chain { get; set; }

		[ForeignKey("NextChainId")]
		public virtual EFChain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>1ded61dd288d000c1e7ba38cccaea117</Hash>
</Codenesium>*/