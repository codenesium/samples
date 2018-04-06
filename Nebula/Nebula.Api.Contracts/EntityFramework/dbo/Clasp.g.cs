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

		[ForeignKey("PreviousChainId")]
		public virtual EFChain ChainRef { get; set; }
		[ForeignKey("NextChainId")]
		public virtual EFChain ChainRef1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>fc113ed2d7c947a4ffd73ffb53e403d2</Hash>
</Codenesium>*/