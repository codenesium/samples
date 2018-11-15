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
			int chainStatusId,
			Guid externalId,
			int id,
			string name,
			int teamId)
		{
			this.ChainStatusId = chainStatusId;
			this.ExternalId = externalId;
			this.Id = id;
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
		public virtual ChainStatus ChainStatusNavigation { get; private set; }

		public void SetChainStatusNavigation(ChainStatus item)
		{
			this.ChainStatusNavigation = item;
		}

		[ForeignKey("TeamId")]
		public virtual Team TeamNavigation { get; private set; }

		public void SetTeamNavigation(Team item)
		{
			this.TeamNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a70dc457218a03a284e97202612605af</Hash>
</Codenesium>*/