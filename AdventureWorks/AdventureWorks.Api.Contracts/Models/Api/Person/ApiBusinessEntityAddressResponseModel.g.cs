using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityAddressResponseModel: AbstractApiResponseModel
	{
		public ApiBusinessEntityAddressResponseModel() : base()
		{}

		public void SetProperties(
			int addressID,
			int addressTypeID,
			int businessEntityID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		public int AddressID { get; private set; }
		public int AddressTypeID { get; private set; }
		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeAddressIDValue { get; set; } = true;

		public bool ShouldSerializeAddressID()
		{
			return this.ShouldSerializeAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressTypeIDValue { get; set; } = true;

		public bool ShouldSerializeAddressTypeID()
		{
			return this.ShouldSerializeAddressTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAddressIDValue = false;
			this.ShouldSerializeAddressTypeIDValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c729d9b9e10e0639a530e3d9a477d179</Hash>
</Codenesium>*/