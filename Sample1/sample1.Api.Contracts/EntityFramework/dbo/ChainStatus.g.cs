using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
    <Hash>05fc7fbc0f79f7fabffc829b7afbbedc</Hash>
</Codenesium>*/