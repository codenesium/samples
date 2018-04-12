using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
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
			this.Name = name;
			this.ShipBase = shipBase;
			this.ShipRate = shipRate;
			this.Rowguid = rowguid;
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
    <Hash>e9b9d8edf5378dbd5d987bd30105a584</Hash>
</Codenesium>*/