using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAddressType
	{
		public POCOAddressType()
		{}

		public POCOAddressType(
			int addressTypeID,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int AddressTypeID { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAddressTypeIDValue { get; set; } = true;

		public bool ShouldSerializeAddressTypeID()
		{
			return this.ShouldSerializeAddressTypeIDValue;
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
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAddressTypeIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c64b8dc0b2b8c674999cbce342a1f5e4</Hash>
</Codenesium>*/