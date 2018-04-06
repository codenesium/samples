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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}
		[Column("linkId", TypeName="int")]
		public int LinkId {get; set;}
		[Column("log", TypeName="text(2147483647)")]
		public string Log {get; set;}
		[Column("dateEntered", TypeName="datetime")]
		public DateTime DateEntered {get; set;}

		[ForeignKey("LinkId")]
		public virtual EFLink LinkRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>33353d31183e8177083a2c03f3a83315</Hash>
</Codenesium>*/