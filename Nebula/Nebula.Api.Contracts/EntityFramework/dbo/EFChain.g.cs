using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace NebulaNS.Api.Contracts
{
	[Table("Chain", Schema="dbo")]
	public partial class EFChain
	{
		public EFChain()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int teamId,
		                          int chainStatusId,
		                          Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.TeamId = teamId.ToInt();
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId;
		}

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
    <Hash>0f4787e270edfacb11b0432e0c03a2fe</Hash>
</Codenesium>*/