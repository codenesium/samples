using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOShipMethod
	{
		public POCOShipMethod()
		{}

		public POCOShipMethod(
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

		public int ShipMethodID { get; set; }
		public string Name { get; set; }
		public decimal ShipBase { get; set; }
		public decimal ShipRate { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

		public bool ShouldSerializeShipMethodID()
		{
			return this.ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipBaseValue { get; set; } = true;

		public bool ShouldSerializeShipBase()
		{
			return this.ShouldSerializeShipBaseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipRateValue { get; set; } = true;

		public bool ShouldSerializeShipRate()
		{
			return this.ShouldSerializeShipRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeShipMethodIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeShipBaseValue = false;
			this.ShouldSerializeShipRateValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>4d95088bf1fc946b542c545d7794c58b</Hash>
</Codenesium>*/