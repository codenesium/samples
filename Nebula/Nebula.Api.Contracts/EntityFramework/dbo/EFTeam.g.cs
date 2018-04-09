using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace NebulaNS.Api.Contracts
{
	[Table("Team", Schema="dbo")]
	public partial class EFTeam
	{
		public EFTeam()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}

		[Column("organizationId", TypeName="int")]
		public int OrganizationId {get; set;}

		public virtual EFOrganization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>41932e2bcbc29bd3dc407571f56bcea3</Hash>
</Codenesium>*/