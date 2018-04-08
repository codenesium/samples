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

		[ForeignKey("teamId")]
		public virtual EFTeam Team { get; set; }
		[ForeignKey("chainStatusId")]
		public virtual EFChainStatus ChainStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>2513221be2f41ab8b1f77aa805d0bad3</Hash>
</Codenesium>*/