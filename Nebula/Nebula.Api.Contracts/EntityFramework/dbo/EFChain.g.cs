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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}

		[Column("teamId", TypeName="int")]
		public int TeamId {get; set;}

		[Column("chainStatusId", TypeName="int")]
		public int ChainStatusId {get; set;}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId {get; set;}

		public virtual EFTeam Team { get; set; }

		public virtual EFChainStatus ChainStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>1ef2aa4ec9a8681eacb94760a423025b</Hash>
</Codenesium>*/