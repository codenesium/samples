using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace NebulaNS.Api.Contracts
{
	[Table("ChainStatus", Schema="dbo")]
	public partial class EFChainStatus
	{
		public EFChainStatus()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>147f4bdcd0b8a1f68938e7f50b1b6288</Hash>
</Codenesium>*/