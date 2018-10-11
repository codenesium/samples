using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vEmployee", Schema="HumanResources")]
	public partial class VEmployee : AbstractEntity
	{
		public VEmployee()
		{
		}

		public virtual void SetProperties(
			string additionalContactInfo,
			string addressLine1,
			string addressLine2,
			int businessEntityID,
			string city,
			string countryRegionName,
			string emailAddress,
			int emailPromotion,
			string firstName,
			string jobTitle,
			string lastName,
			string middleName,
			string phoneNumber,
			string phoneNumberType,
			string postalCode,
			string stateProvinceName,
			string suffix,
			string title)
		{
			this.AdditionalContactInfo = additionalContactInfo;
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.BusinessEntityID = businessEntityID;
			this.City = city;
			this.CountryRegionName = countryRegionName;
			this.EmailAddress = emailAddress;
			this.EmailPromotion = emailPromotion;
			this.FirstName = firstName;
			this.JobTitle = jobTitle;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberType = phoneNumberType;
			this.PostalCode = postalCode;
			this.StateProvinceName = stateProvinceName;
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("AdditionalContactInfo")]
		public string AdditionalContactInfo { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine1")]
		public string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public string AddressLine2 { get; private set; }

		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegionName")]
		public string CountryRegionName { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public string EmailAddress { get; private set; }

		[Column("EmailPromotion")]
		public int EmailPromotion { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("JobTitle")]
		public string JobTitle { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public string MiddleName { get; private set; }

		[MaxLength(25)]
		[Column("PhoneNumber")]
		public string PhoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("PhoneNumberType")]
		public string PhoneNumberType { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public string PostalCode { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public string StateProvinceName { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e3ee788d84c2f5fba485ac4dd9bad0a5</Hash>
</Codenesium>*/