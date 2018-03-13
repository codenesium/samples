using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Organization", Schema="dbo")]
	public partial class Organization
	{
		public Organization()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>00539de9d83e05009ba71f07ed6c813d</Hash>
</Codenesium>*/