using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPerson
	{
		public POCOPerson()
		{}

		public POCOPerson(
			int businessEntityID,
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
			this.PersonType = personType.ToString();
			this.NameStyle = nameStyle.ToBoolean();
			this.Title = title.ToString();
			this.FirstName = firstName.ToString();
			this.MiddleName = middleName.ToString();
			this.LastName = lastName.ToString();
			this.Suffix = suffix.ToString();
			this.EmailPromotion = emailPromotion.ToInt();
			this.AdditionalContactInfo = additionalContactInfo;
			this.Demographics = demographics;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.BusinessEntities));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public string PersonType { get; set; }
		public bool NameStyle { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Suffix { get; set; }
		public int EmailPromotion { get; set; }
		public string AdditionalContactInfo { get; set; }
		public string Demographics { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonTypeValue { get; set; } = true;

		public bool ShouldSerializePersonType()
		{
			return this.ShouldSerializePersonTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameStyleValue { get; set; } = true;

		public bool ShouldSerializeNameStyle()
		{
			return this.ShouldSerializeNameStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTitleValue { get; set; } = true;

		public bool ShouldSerializeTitle()
		{
			return this.ShouldSerializeTitleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMiddleNameValue { get; set; } = true;

		public bool ShouldSerializeMiddleName()
		{
			return this.ShouldSerializeMiddleNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSuffixValue { get; set; } = true;

		public bool ShouldSerializeSuffix()
		{
			return this.ShouldSerializeSuffixValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailPromotionValue { get; set; } = true;

		public bool ShouldSerializeEmailPromotion()
		{
			return this.ShouldSerializeEmailPromotionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAdditionalContactInfoValue { get; set; } = true;

		public bool ShouldSerializeAdditionalContactInfo()
		{
			return this.ShouldSerializeAdditionalContactInfoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDemographicsValue { get; set; } = true;

		public bool ShouldSerializeDemographics()
		{
			return this.ShouldSerializeDemographicsValue;
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
    <Hash>d8656ee0bcebfae76513f70d6bda68b0</Hash>
</Codenesium>*/