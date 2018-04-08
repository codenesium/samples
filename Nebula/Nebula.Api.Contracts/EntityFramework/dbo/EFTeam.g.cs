using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Team", Schema="dbo")]
	public partial class EFTeam
	{
		public EFTeam()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}

		[Column("organizationId", TypeName="int")]
		public int OrganizationId {get; set;}

		[ForeignKey("organizationId")]
		public virtual EFOrganization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>2f02c7fe566207228738e70701baa908</Hash>
</Codenesium>*/