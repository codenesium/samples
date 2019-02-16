using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("Chain", Schema="dbo")]
	public partial class Chain : AbstractEntity
	{
		public Chain()
		{
		}

		public virtual void SetProperties(
			int id,
			int chainStatusId,
			Guid externalId,
			string name,
			int teamId)
		{
			this.Id = id;
			this.ChainStatusId = chainStatusId;
			this.ExternalId = externalId;
			this.Name = name;
			this.TeamId = teamId;
		}

		[Column("chainStatusId")]
		public virtual int ChainStatusId { get; private set; }

		[Column("externalId")]
		public virtual Guid ExternalId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("teamId")]
		public virtual int TeamId { get; private set; }

		[ForeignKey("ChainStatusId")]
		public virtual ChainStatus ChainStatusIdNavigation { get; private set; }

		public void SetChainStatusIdNavigation(ChainStatus item)
		{
			this.ChainStatusIdNavigation = item;
		}

		[ForeignKey("TeamId")]
		public virtual Team TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(Team item)
		{
			this.TeamIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>797653c245fd7de9ebe570c11eb18f02</Hash>
</Codenesium>*/