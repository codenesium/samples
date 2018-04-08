using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAddressType
	{
		public POCOAddressType()
		{}

		public POCOAddressType(int addressTypeID,
		                       string name,
		                       Guid rowguid,
		                       DateTime modifiedDate)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int AddressTypeID {get; set;}
		public string Name {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeAddressTypeIDValue {get; set;} = true;

		public bool ShouldSerializeAddressTypeID()
		{
			return ShouldSerializeAddressTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>e1820ec44d6cde55e88c902c5fd1b73f</Hash>
</Codenesium>*/