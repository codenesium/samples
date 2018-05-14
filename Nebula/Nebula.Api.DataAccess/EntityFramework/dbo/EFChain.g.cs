using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Chain", Schema="dbo")]
	public partial class Chain:AbstractEntityFrameworkPOCO
	{
		public Chain()
		{}

		public void SetProperties(
			int id,
			int chainStatusId,
			Guid externalId,
			string name,
			int teamId)
		{
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.TeamId = teamId.ToInt();
		}

		[Column("chainStatusId", TypeName="int")]
		public int ChainStatusId { get; set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("teamId", TypeName="int")]
		public int TeamId { get; set; }

		[ForeignKey("ChainStatusId")]
		public virtual ChainStatus ChainStatus { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>042d4049a06ffe35efde1dc19ca1d8e3</Hash>
</Codenesium>*/