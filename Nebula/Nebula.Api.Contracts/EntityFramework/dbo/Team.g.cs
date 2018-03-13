using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Team", Schema="dbo")]
	public partial class Team
	{
		public Team()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public int organizationId {get; set;}

		[ForeignKey("organizationId")]
		public virtual Organization OrganizationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>1d316727ef956a25fef2d2b94f681e5b</Hash>
</Codenesium>*/