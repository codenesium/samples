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
		public string CountryRegionCode {get; set;}
		public string CurrencyCode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegionRef { get; set; }
		[ForeignKey("CurrencyCode")]
		public virtual EFCurrency CurrencyRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>af54bddc6142a6ef21223f8f4d6e5a23</Hash>
</Codenesium>*/