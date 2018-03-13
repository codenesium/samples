using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    <Hash>e20fab185746304ac14db81276f424ff</Hash>
</Codenesium>*/