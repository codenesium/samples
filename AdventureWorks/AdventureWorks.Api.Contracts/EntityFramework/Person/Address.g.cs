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
		public int AddressID {get; set;}
		public string AddressLine1 {get; set;}
		public string AddressLine2 {get; set;}
		public string City {get; set;}
		public int StateProvinceID {get; set;}
		public string PostalCode {get; set;}
		public object SpatialLocation {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("StateProvinceID")]
		public virtual EFStateProvince StateProvinceRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>637c8232b6c7c13f556390c16690004a</Hash>
</Codenesium>*/