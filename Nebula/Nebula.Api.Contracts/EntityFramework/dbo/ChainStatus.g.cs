using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("ChainStatus", Schema="dbo")]
	public partial class EFChainStatus
	{
		public EFChainStatus()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>a8c3cdaf2e6854dc6db79209c54eb976</Hash>
</Codenesium>*/