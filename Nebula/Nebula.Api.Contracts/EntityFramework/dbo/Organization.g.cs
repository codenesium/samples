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
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>61679a42f37fc67cc461e6c2af56110e</Hash>
</Codenesium>*/