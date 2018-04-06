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
		                        string emailAddress1,
		                        Guid rowguid,
		                        DateTime modifiedDate)
		{
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress1 = emailAddress1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Person");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public int EmailAddressID {get; set;}
		public string EmailAddress1 {get; set;}
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
		public bool ShouldSerializeEmailAddress1Value {get; set;} = true;

		public bool ShouldSerializeEmailAddress1()
		{
			return ShouldSerializeEmailAddress1Value;
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
			this.ShouldSerializeEmailAddress1Value = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7449245527dccae955639657b020ba8d</Hash>
</Codenesium>*/