using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Chain", Schema="dbo")]
	public partial class Chain:AbstractEntity
	{
		public Chain()
		{}

		public void SetProperties(
			int chainStatusId,
			Guid externalId,
			int id,
			string name,
			int teamId)
		{
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
			this.TeamId = teamId.ToInt();
		}

		[Column("chainStatusId", TypeName="int")]
		public int ChainStatusId { get; private set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("teamId", TypeName="int")]
		public int TeamId { get; private set; }

		[ForeignKey("ChainStatusId")]
		public virtual ChainStatus ChainStatus { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>4934a324f1baf0f89a9e67b6c6ab4f12</Hash>
</Codenesium>*/