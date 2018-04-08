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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ShipBase", TypeName="money")]
		public decimal ShipBase {get; set;}

		[Column("ShipRate", TypeName="money")]
		public decimal ShipRate {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3cb34ea0b0f96c96a84c800aa1513c08</Hash>
</Codenesium>*/