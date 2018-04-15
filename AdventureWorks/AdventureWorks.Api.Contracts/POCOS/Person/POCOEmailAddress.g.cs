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
			int emailAddressID,
			string emailAddress1,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress1 = emailAddress1.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.People));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public int EmailAddressID { get; set; }
		public string EmailAddress1 { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressIDValue { get; set; } = true;

		public bool ShouldSerializeEmailAddressID()
		{
			return this.ShouldSerializeEmailAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddress1Value { get; set; } = true;

		public bool ShouldSerializeEmailAddress1()
		{
			return this.ShouldSerializeEmailAddress1Value;
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
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeEmailAddressIDValue = false;
			this.ShouldSerializeEmailAddress1Value = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>543daa04bd005f9e8bf85a11349843b2</Hash>
</Codenesium>*/