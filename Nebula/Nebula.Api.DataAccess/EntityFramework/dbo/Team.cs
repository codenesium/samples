using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Team", Schema="dbo")]
	public partial class Team:AbstractEntityFrameworkPOCO
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
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("organizationId", TypeName="int")]
		public int OrganizationId { get; set; }

		[ForeignKey("OrganizationId")]
		public virtual Organization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>000680b2234bf447dc0f61de2fad9a9c</Hash>
</Codenesium>*/