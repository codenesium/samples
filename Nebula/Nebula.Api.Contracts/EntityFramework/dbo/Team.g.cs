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
		public int id {get; set;}
		public string name {get; set;}
		public int organizationId {get; set;}

		[ForeignKey("organizationId")]
		public virtual EFOrganization OrganizationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>f9da38ae82d5d560418431c784968392</Hash>
</Codenesium>*/