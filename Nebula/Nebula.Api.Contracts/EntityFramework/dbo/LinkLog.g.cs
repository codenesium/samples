using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("LinkLog", Schema="dbo")]
	public partial class EFLinkLog
	{
		public EFLinkLog()
		{}

		[Key]
		public int id {get; set;}
		public int linkId {get; set;}
		public string log {get; set;}
		public DateTime dateEntered {get; set;}

		[ForeignKey("linkId")]
		public virtual EFLink LinkRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>2bd4212d36870948a80ecadaa57bdd10</Hash>
</Codenesium>*/