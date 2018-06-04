using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPhoneNumberTypeResponseModel: AbstractApiResponseModel
	{
		public ApiPhoneNumberTypeResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			int phoneNumberTypeID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int PhoneNumberTypeID { get; private set; }

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
		public bool ShouldSerializePhoneNumberTypeIDValue { get; set; } = true;

		public bool ShouldSerializePhoneNumberTypeID()
		{
			return this.ShouldSerializePhoneNumberTypeIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializePhoneNumberTypeIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>00b7128d08f01ed55cf76944e85df4e7</Hash>
</Codenesium>*/