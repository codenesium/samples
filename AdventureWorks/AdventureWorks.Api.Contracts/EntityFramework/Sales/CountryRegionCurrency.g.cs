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
		public string countryRegionCode {get; set;}
		public string currencyCode {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>9465808a137194eadb3df4083a45e2a0</Hash>
</Codenesium>*/