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

		[ForeignKey("previousChainId")]
		public virtual EFChain Chain { get; set; }
		[ForeignKey("nextChainId")]
		public virtual EFChain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>4f379f61a2709eeed9621654f0827397</Hash>
</Codenesium>*/