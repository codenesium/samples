using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CountryRegion", Schema="Person")]
	public partial class EFCountryRegion
	{
		public EFCountryRegion()
		{}

		[Key]
		public string countryRegionCode {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7d1d9708bda2cf40bdf8744f1c4eb4b6</Hash>
</Codenesium>*/