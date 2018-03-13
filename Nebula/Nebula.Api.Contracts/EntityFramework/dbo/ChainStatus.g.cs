using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("ChainStatus", Schema="dbo")]
	public partial class ChainStatus
	{
		public ChainStatus()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>54c0a5a5545cdc814ce3282e0048880f</Hash>
</Codenesium>*/