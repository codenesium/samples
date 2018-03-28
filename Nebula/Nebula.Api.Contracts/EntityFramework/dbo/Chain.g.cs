using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Chain", Schema="dbo")]
	public partial class EFChain
	{
		public EFChain()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public int teamId {get; set;}
		public int chainStatusId {get; set;}
		public Guid externalId {get; set;}

		[ForeignKey("teamId")]
		public virtual EFTeam TeamRef { get; set; }
		[ForeignKey("chainStatusId")]
		public virtual EFChainStatus ChainStatusRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>fef8d914aaa7b61652a5a6daa385ccf8</Hash>
</Codenesium>*/