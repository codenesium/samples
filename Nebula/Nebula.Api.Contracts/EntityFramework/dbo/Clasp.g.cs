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
		public int id {get; set;}
		public int previousChainId {get; set;}
		public int nextChainId {get; set;}

		[ForeignKey("previousChainId")]
		public virtual EFChain ChainRef { get; set; }
		[ForeignKey("nextChainId")]
		public virtual EFChain ChainRef1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>f4ca24bbae3bb3c00f0d83db3e266eef</Hash>
</Codenesium>*/