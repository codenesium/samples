using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Currency", Schema="Sales")]
	public partial class EFCurrency
	{
		public EFCurrency()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CurrencyCode", TypeName="nchar(3)")]
		public string CurrencyCode {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>98924fdbed1a4c6cd979cd9d9b610ca8</Hash>
</Codenesium>*/