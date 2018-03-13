using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("LinkStatus", Schema="dbo")]
	public partial class LinkStatus
	{
		public LinkStatus()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>da9d517d478a9321167864fb152fb5cf</Hash>
</Codenesium>*/