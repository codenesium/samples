using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Location", Schema="Production")]
	public partial class EFLocation
	{
		public EFLocation()
		{}

		[Key]
		public short LocationID {get; set;}
		public string Name {get; set;}
		public decimal CostRate {get; set;}
		public decimal Availability {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>0f041d1796f8e0e111bfeb8f3d6d087f</Hash>
</Codenesium>*/