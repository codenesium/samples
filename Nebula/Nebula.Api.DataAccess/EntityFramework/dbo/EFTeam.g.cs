using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Team", Schema="dbo")]
	public partial class EFTeam:AbstractEntityFrameworkPOCO
	{
		public EFTeam()
		{}

		public void SetProperties(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.OrganizationId = organizationId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("organizationId", TypeName="int")]
		public int OrganizationId { get; set; }

		[ForeignKey("OrganizationId")]
		public virtual EFOrganization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>a48e3fa3092fa34d6cd48cb60f05071a</Hash>
</Codenesium>*/