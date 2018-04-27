using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShipMethod", Schema="Purchasing")]
	public partial class EFShipMethod: AbstractEntityFrameworkPOCO
	{
		public EFShipMethod()
		{}

		public void SetProperties(
			int shipMethodID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipRate = shipRate.ToDecimal();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ShipBase", TypeName="money")]
		public decimal ShipBase { get; set; }

		[Key]
		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; set; }

		[Column("ShipRate", TypeName="money")]
		public decimal ShipRate { get; set; }
	}
}

/*<Codenesium>
    <Hash>a1769e461661f4de814854448258d709</Hash>
</Codenesium>*/