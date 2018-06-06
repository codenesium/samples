using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Team", Schema="dbo")]
	public partial class Team:AbstractEntity
	{
		public Team()
		{}

		public void SetProperties(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("organizationId", TypeName="int")]
		public int OrganizationId { get; private set; }

		[ForeignKey("OrganizationId")]
		public virtual Organization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>c7cf9c9f45168730096dcd5fc82f09c6</Hash>
</Codenesium>*/