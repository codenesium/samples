using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vSalesPerson", Schema="Sales")]
	public partial class VSalesPerson : AbstractEntity
	{
		public VSalesPerson()
		{
		}

		public virtual void SetProperties(
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
			decimal salesLastYear,
			decimal? salesQuota,
			decimal salesYTD,
			string stateProvinceName,
			string suffix,
			string territoryGroup,
			string territoryName,
			string title)
		{
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
			this.SalesLastYear = salesLastYear;
			this.SalesQuota = salesQuota;
			this.SalesYTD = salesYTD;
			this.StateProvinceName = stateProvinceName;
			this.Suffix = suffix;
			this.TerritoryGroup = territoryGroup;
			this.TerritoryName = territoryName;
			this.Title = title;
		}

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

		[Column("SalesLastYear")]
		public decimal SalesLastYear { get; private set; }

		[Column("SalesQuota")]
		public decimal? SalesQuota { get; private set; }

		[Column("SalesYTD")]
		public decimal SalesYTD { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public string StateProvinceName { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public string Suffix { get; private set; }

		[MaxLength(50)]
		[Column("TerritoryGroup")]
		public string TerritoryGroup { get; private set; }

		[MaxLength(50)]
		[Column("TerritoryName")]
		public string TerritoryName { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a2c7a58e64cec221e645e9f3c9a096ae</Hash>
</Codenesium>*/