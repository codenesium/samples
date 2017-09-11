using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
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
		public virtual Link LinkRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>11b21fc60086caf44c60498f1dd3523e</Hash>
</Codenesium>*/