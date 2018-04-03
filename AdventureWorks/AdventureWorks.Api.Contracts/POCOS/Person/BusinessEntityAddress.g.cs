using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOBusinessEntityAddress
	{
		public POCOBusinessEntityAddress()
		{}

		public POCOBusinessEntityAddress(int businessEntityID,
		                                 int addressID,
		                                 int addressTypeID,
		                                 Guid rowguid,
		                                 DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public int AddressID {get; set;}
		public int AddressTypeID {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressIDValue {get; set;} = true;

		public bool ShouldSerializeAddressID()
		{
			return ShouldSerializeAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressTypeIDValue {get; set;} = true;

		public bool ShouldSerializeAddressTypeID()
		{
			return ShouldSerializeAddressTypeIDValue;
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
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeAddressIDValue = false;
			this.ShouldSerializeAddressTypeIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b85a9b56bbf61b7b9dbc13c52602bee5</Hash>
</Codenesium>*/