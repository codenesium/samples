using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPerson
	{
		public POCOPerson()
		{}

		public POCOPerson(int businessEntityID,
		                  string personType,
		                  bool nameStyle,
		                  string title,
		                  string firstName,
		                  string middleName,
		                  string lastName,
		                  string suffix,
		                  int emailPromotion,
		                  string additionalContactInfo,
		                  string demographics,
		                  Guid rowguid,
		                  DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PersonType = personType;
			this.NameStyle = nameStyle;
			this.Title = title;
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.Suffix = suffix;
			this.EmailPromotion = emailPromotion.ToInt();
			this.AdditionalContactInfo = additionalContactInfo;
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public string PersonType {get; set;}
		public bool NameStyle {get; set;}
		public string Title {get; set;}
		public string FirstName {get; set;}
		public string MiddleName {get; set;}
		public string LastName {get; set;}
		public string Suffix {get; set;}
		public int EmailPromotion {get; set;}
		public string AdditionalContactInfo {get; set;}
		public string Demographics {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonTypeValue {get; set;} = true;

		public bool ShouldSerializePersonType()
		{
			return ShouldSerializePersonTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameStyleValue {get; set;} = true;

		public bool ShouldSerializeNameStyle()
		{
			return ShouldSerializeNameStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTitleValue {get; set;} = true;

		public bool ShouldSerializeTitle()
		{
			return ShouldSerializeTitleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue {get; set;} = true;

		public bool ShouldSerializeFirstName()
		{
			return ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMiddleNameValue {get; set;} = true;

		public bool ShouldSerializeMiddleName()
		{
			return ShouldSerializeMiddleNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue {get; set;} = true;

		public bool ShouldSerializeLastName()
		{
			return ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSuffixValue {get; set;} = true;

		public bool ShouldSerializeSuffix()
		{
			return ShouldSerializeSuffixValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailPromotionValue {get; set;} = true;

		public bool ShouldSerializeEmailPromotion()
		{
			return ShouldSerializeEmailPromotionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAdditionalContactInfoValue {get; set;} = true;

		public bool ShouldSerializeAdditionalContactInfo()
		{
			return ShouldSerializeAdditionalContactInfoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDemographicsValue {get; set;} = true;

		public bool ShouldSerializeDemographics()
		{
			return ShouldSerializeDemographicsValue;
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
			this.ShouldSerializePersonTypeValue = false;
			this.ShouldSerializeNameStyleValue = false;
			this.ShouldSerializeTitleValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeMiddleNameValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializeSuffixValue = false;
			this.ShouldSerializeEmailPromotionValue = false;
			this.ShouldSerializeAdditionalContactInfoValue = false;
			this.ShouldSerializeDemographicsValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>45801046d4e4017136ecfc3ca4699773</Hash>
</Codenesium>*/