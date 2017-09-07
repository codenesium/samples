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
		public virtual Link Link { get; set; }
	}
}

/*<Codenesium>
    <Hash>b5dc37e8130dd91345b6cc9480df1e2d</Hash>
</Codenesium>*/