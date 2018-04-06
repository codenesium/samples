using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CountryRegionCurrency", Schema="Sales")]
	public partial class EFCountryRegionCurrency
	{
		public EFCountryRegionCurrency()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode {get; set;}
		[Column("CurrencyCode", TypeName="nchar(3)")]
		public string CurrencyCode {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegionRef { get; set; }
		[ForeignKey("CurrencyCode")]
		public virtual EFCurrency CurrencyRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>8b207ee4e3173956d5256c9eb7d2fd7b</Hash>
</Codenesium>*/