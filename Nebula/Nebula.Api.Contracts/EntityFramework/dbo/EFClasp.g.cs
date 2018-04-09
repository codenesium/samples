using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Clasp", Schema="dbo")]
	public partial class EFClasp
	{
		public EFClasp()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("previousChainId", TypeName="int")]
		public int PreviousChainId {get; set;}

		[Column("nextChainId", TypeName="int")]
		public int NextChainId {get; set;}

		public virtual EFChain Chain { get; set; }

		public virtual EFChain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>3c6db5e9cf724c36b68f7dc458a1769a</Hash>
</Codenesium>*/