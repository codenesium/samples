using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Address", Schema="Person")]
	public partial class EFAddress
	{
		public EFAddress()
		{}

		[Key]
		public int addressID {get; set;}
		public string addressLine1 {get; set;}
		public string addressLine2 {get; set;}
		public string city {get; set;}
		public int stateProvinceID {get; set;}
		public string postalCode {get; set;}
		public object spatialLocation {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>606b1c966ad16892ebf1377e7a6754c8</Hash>
</Codenesium>*/