using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
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
    <Hash>591a984a5d13b53ddf19abbd46c559c4</Hash>
</Codenesium>*/