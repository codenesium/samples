using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Organization", Schema="dbo")]
	public partial class EFOrganization
	{
		public EFOrganization()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>18518b8c287bfad053734f649bb1c7cf</Hash>
</Codenesium>*/