using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmailAddressResponseModel: AbstractApiResponseModel
	{
		public ApiEmailAddressResponseModel() : base()
		{}

		public void SetProperties(
			int businessEntityID,
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddress1 = emailAddress1;
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
    <Hash>76a63257d1594c4a58d1d768f95d01cf</Hash>
</Codenesium>*/