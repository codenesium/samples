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
		public int shipMethodID {get; set;}
		public string name {get; set;}
		public decimal shipBase {get; set;}
		public decimal shipRate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e5ff1027869d50b92b48e7270b3ec9fc</Hash>
</Codenesium>*/