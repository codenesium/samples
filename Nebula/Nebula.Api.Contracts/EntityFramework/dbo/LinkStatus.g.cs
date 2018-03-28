using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("LinkStatus", Schema="dbo")]
	public partial class EFLinkStatus
	{
		public EFLinkStatus()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>67ec0e086c8521df1e61b7389775ea69</Hash>
</Codenesium>*/