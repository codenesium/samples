using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("StateProvince", Schema="Person")]
	public partial class EFStateProvince
	{
		public EFStateProvince()
		{}

		[Key]
		public int stateProvinceID {get; set;}
		public string stateProvinceCode {get; set;}
		public string countryRegionCode {get; set;}
		public bool isOnlyStateProvinceFlag {get; set;}
		public string name {get; set;}
		public int territoryID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>75d47eb934b4b3fe1e3fcc6ae4051bc4</Hash>
</Codenesium>*/