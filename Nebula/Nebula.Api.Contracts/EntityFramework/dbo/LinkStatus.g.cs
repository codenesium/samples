using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("LinkStatus", Schema="dbo")]
	public partial class EFLinkStatus
	{
		public EFLinkStatus()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}
		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>cb1115ac50d80a2ccffa3e72b2b2ae61</Hash>
</Codenesium>*/