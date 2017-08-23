using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
    <Hash>fdeeb9e9d63590189d278c5e92427f16</Hash>
</Codenesium>*/