using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ShipMethod", Schema="Purchasing")]
	public partial class EFShipMethod
	{
		public EFShipMethod()
		{}

		[Key]
		public int ShipMethodID {get; set;}
		public string Name {get; set;}
		public decimal ShipBase {get; set;}
		public decimal ShipRate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3459db330cb0dcd40f145b92342155b7</Hash>
</Codenesium>*/