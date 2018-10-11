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
		public int ChainStatusId { get; private set; }

		[Column("externalId")]
		public Guid ExternalId { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("teamId")]
		public int TeamId { get; private set; }

		[ForeignKey("ChainStatusId")]
		public virtual ChainStatus ChainStatusNavigation { get; private set; }

		[ForeignKey("TeamId")]
		public virtual Team TeamNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1f960561cedb818427182d230264fd56</Hash>
</Codenesium>*/