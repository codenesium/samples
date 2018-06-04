using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShipMethodResponseModel: AbstractApiResponseModel
	{
		public ApiShipMethodResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			int shipMethodID,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipRate = shipRate.ToDecimal();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public decimal ShipBase { get; private set; }
		public int ShipMethodID { get; private set; }
		public decimal ShipRate { get; private set; }

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
    <Hash>445deb2f8a5fa724ba1e62935d51860b</Hash>
</Codenesium>*/