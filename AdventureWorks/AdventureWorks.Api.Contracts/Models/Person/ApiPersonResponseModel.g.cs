using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonResponseModel: AbstractApiResponseModel
	{
		public ApiPersonResponseModel() : base()
		{}

		public void SetProperties(
			string additionalContactInfo,
			int businessEntityID,
			string demographics,
			int emailPromotion,
			string firstName,
			string lastName,
			string middleName,
			DateTime modifiedDate,
			bool nameStyle,
			string personType,
			Guid rowguid,
			string suffix,
			string title)
		{
			this.AdditionalContactInfo = additionalContactInfo;
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.EmailPromotion = emailPromotion.ToInt();
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NameStyle = nameStyle.ToBoolean();
			this.PersonType = personType;
			this.Rowguid = rowguid.ToGuid();
			this.Suffix = suffix;
			this.Title = title;
		}

		public string AdditionalContactInfo { get; set; }
		public int BusinessEntityID { get; set; }
		public string Demographics { get; set; }
		public int EmailPromotion { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool NameStyle { get; set; }
		public string PersonType { get; set; }
		public Guid Rowguid { get; set; }
		public string Suffix { get; set; }
		public string Title { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAdditionalContactInfoValue { get; set; } = true;

		public bool ShouldSerializeAdditionalContactInfo()
		{
			return this.ShouldSerializeAdditionalContactInfoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDemographicsValue { get; set; } = true;

		public bool ShouldSerializeDemographics()
		{
			return this.ShouldSerializeDemographicsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailPromotionValue { get; set; } = true;

		public bool ShouldSerializeEmailPromotion()
		{
			return this.ShouldSerializeEmailPromotionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMiddleNameValue { get; set; } = true;

		public bool ShouldSerializeMiddleName()
		{
			return this.ShouldSerializeMiddleNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameStyleValue { get; set; } = true;

		public bool ShouldSerializeNameStyle()
		{
			return this.ShouldSerializeNameStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonTypeValue { get; set; } = true;

		public bool ShouldSerializePersonType()
		{
			return this.ShouldSerializePersonTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSuffixValue { get; set; } = true;

		public bool ShouldSerializeSuffix()
		{
			return this.ShouldSerializeSuffixValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTitleValue { get; set; } = true;

		public bool ShouldSerializeTitle()
		{
			return this.ShouldSerializeTitleValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAdditionalContactInfoValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeDemographicsValue = false;
			this.ShouldSerializeEmailPromotionValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializeMiddleNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameStyleValue = false;
			this.ShouldSerializePersonTypeValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSuffixValue = false;
			this.ShouldSerializeTitleValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>bdfe6ea8f949fb2f5d6f4dac3e44bcbb</Hash>
</Codenesium>*/