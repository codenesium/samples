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
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			int shipMethodID,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipRate = shipRate.ToDecimal();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public decimal ShipBase { get; set; }
		public int ShipMethodID { get; set; }
		public decimal ShipRate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipBaseValue { get; set; } = true;

		public bool ShouldSerializeShipBase()
		{
			return this.ShouldSerializeShipBaseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

		public bool ShouldSerializeShipMethodID()
		{
			return this.ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipRateValue { get; set; } = true;

		public bool ShouldSerializeShipRate()
		{
			return this.ShouldSerializeShipRateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeShipBaseValue = false;
			this.ShouldSerializeShipMethodIDValue = false;
			this.ShouldSerializeShipRateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a15b3ad59775cd791f5cbbafc6f36857</Hash>
</Codenesium>*/