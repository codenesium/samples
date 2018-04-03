using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmailAddress
	{
		public POCOEmailAddress()
		{}

		public POCOEmailAddress(int businessEntityID,
		                        int emailAddressID,
		                        string emailAddress,
		                        Guid rowguid,
		                        DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress = emailAddress;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public int EmailAddressID {get; set;}
		public string EmailAddress {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressIDValue {get; set;} = true;

		public bool ShouldSerializeEmailAddressID()
		{
			return ShouldSerializeEmailAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressValue {get; set;} = true;

		public bool ShouldSerializeEmailAddress()
		{
			return ShouldSerializeEmailAddressValue;
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
			this.ShouldSerializeEmailAddressIDValue = false;
			this.ShouldSerializeEmailAddressValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8a48f073a86f30dcf2e03bfadfdae0fe</Hash>
</Codenesium>*/