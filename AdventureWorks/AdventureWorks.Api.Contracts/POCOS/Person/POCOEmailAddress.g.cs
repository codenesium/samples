using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmailAddress
	{
		public POCOEmailAddress()
		{}

		public POCOEmailAddress(
			int businessEntityID,
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddress1 = emailAddress1.ToString();
			this.EmailAddressID = emailAddressID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		public int BusinessEntityID { get; set; }
		public string EmailAddress1 { get; set; }
		public int EmailAddressID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddress1Value { get; set; } = true;

		public bool ShouldSerializeEmailAddress1()
		{
			return this.ShouldSerializeEmailAddress1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressIDValue { get; set; } = true;

		public bool ShouldSerializeEmailAddressID()
		{
			return this.ShouldSerializeEmailAddressIDValue;
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
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeEmailAddress1Value = false;
			this.ShouldSerializeEmailAddressIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ac9e0fc51ed5a5b8abb8295e37d4684c</Hash>
</Codenesium>*/