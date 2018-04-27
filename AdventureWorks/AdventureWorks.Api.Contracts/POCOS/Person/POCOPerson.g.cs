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
			this.Demographics = demographics;
			this.EmailPromotion = emailPromotion.ToInt();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.MiddleName = middleName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NameStyle = nameStyle.ToBoolean();
			this.PersonType = personType.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.Suffix = suffix.ToString();
			this.Title = title.ToString();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.BusinessEntities));
		}

		public string AdditionalContactInfo { get; set; }
		public ReferenceEntity<int> BusinessEntityID { get; set; }
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
    <Hash>13c2e5c2337c5b7433fcf69e551aa9b6</Hash>
</Codenesium>*/