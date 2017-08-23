using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
{
	[Table("LinkLog", Schema="dbo")]
	public partial class LinkLog
	{
		public LinkLog()
		{}

		public DateTime dateEntered {get; set;}
		[Key]
		public int id {get; set;}
		public int linkId {get; set;}
		public string log {get; set;}

		[ForeignKey("linkId")]
		public virtual Link Link { get; set; }
	}
}

/*<Codenesium>
    <Hash>5a4da7caae772fb2aad4ab0ee073df3b</Hash>
</Codenesium>*/