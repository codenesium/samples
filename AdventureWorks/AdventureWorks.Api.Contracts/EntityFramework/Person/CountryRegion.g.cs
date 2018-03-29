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
		public string CountryRegionCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>26ca51ffddd9dc769e5f5e3468579153</Hash>
</Codenesium>*/