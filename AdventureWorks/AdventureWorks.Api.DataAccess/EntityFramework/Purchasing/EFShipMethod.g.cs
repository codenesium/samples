using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShipMethod", Schema="Purchasing")]
	public partial class EFShipMethod
	{
		public EFShipMethod()
		{}

		public void SetProperties(
			int shipMethodID,
			string name,
			decimal shipBase,
			decimal shipRate,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ShipMethodID = shipMethodID.ToInt();
			this.Name = name.ToString();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipRate = shipRate.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ShipBase", TypeName="money")]
		public decimal ShipBase { get; set; }

		[Column("ShipRate", TypeName="money")]
		public decimal ShipRate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>80f3f58f812cfed0475f9cba80938ea3</Hash>
</Codenesium>*/