using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAddressType: AbstractPOCO
	{
		public POCOAddressType() : base()
		{}

		public POCOAddressType(
			int addressTypeID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
		}

		public int AddressTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAddressTypeIDValue { get; set; } = true;

		public bool ShouldSerializeAddressTypeID()
		{
			return this.ShouldSerializeAddressTypeIDValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeAddressTypeIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>aca72afe44b555f652c02aa37227b14e</Hash>
</Codenesium>*/