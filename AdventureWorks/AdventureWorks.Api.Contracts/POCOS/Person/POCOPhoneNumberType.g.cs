using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPhoneNumberType: AbstractPOCO
	{
		public POCOPhoneNumberType() : base()
		{}

		public POCOPhoneNumberType(
			DateTime modifiedDate,
			string name,
			int phoneNumberTypeID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int PhoneNumberTypeID { get; set; }

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
    <Hash>1fda2c0deb459776702cfe5d704c907d</Hash>
</Codenesium>*/