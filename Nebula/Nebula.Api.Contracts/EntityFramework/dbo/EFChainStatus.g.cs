using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("ChainStatus", Schema="dbo")]
	public partial class EFChainStatus
	{
		public EFChainStatus()
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
    <Hash>02cdfb5a52665822c0aa6ed332813125</Hash>
</Codenesium>*/