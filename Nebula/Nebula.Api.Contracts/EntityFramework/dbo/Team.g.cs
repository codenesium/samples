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

		[ForeignKey("OrganizationId")]
		public virtual EFOrganization OrganizationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>29ac57593e48ee15df572bd7d4b482d5</Hash>
</Codenesium>*/