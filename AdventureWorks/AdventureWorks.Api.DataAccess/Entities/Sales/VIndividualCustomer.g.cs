using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vIndividualCustomer", Schema="Sales")]
	public partial class VIndividualCustomer : AbstractEntity
	{
		public VIndividualCustomer()
		{
		}

		public virtual void SetProperties(
			string addressLine1,
			string addressLine2,
			string addressType,
			int businessEntityID,
			string city,
			string countryRegionName,
			string demographic,
			string emailAddress,
			int emailPromotion,
			string firstName,
			string lastName,
			string middleName,
			string phoneNumber,
			string phoneNumberType,
			string postalCode,
			string stateProvinceName,
			string suffix,
			string title)
		{
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.AddressType = addressType;
			this.BusinessEntityID = businessEntityID;
			this.City = city;
			this.CountryRegionName = countryRegionName;
			this.Demographic = demographic;
			this.EmailAddress = emailAddress;
			this.EmailPromotion = emailPromotion;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberType = phoneNumberType;
			this.PostalCode = postalCode;
			this.StateProvinceName = stateProvinceName;
			this.Suffix = suffix;
			this.Title = title;
		}

		[MaxLength(60)]
		[Column("AddressLine1")]
		public virtual string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public virtual string AddressLine2 { get; private set; }

		[MaxLength(50)]
		[Column("AddressType")]
		public virtual string AddressType { get; private set; }

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public virtual string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegionName")]
		public virtual string CountryRegionName { get; private set; }

		[Column("Demographics")]
		public virtual string Demographic { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public virtual string EmailAddress { get; private set; }

		[Column("EmailPromotion")]
		public virtual int EmailPromotion { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public virtual string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public virtual string MiddleName { get; private set; }

		[MaxLength(25)]
		[Column("PhoneNumber")]
		public virtual string PhoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("PhoneNumberType")]
		public virtual string PhoneNumberType { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public virtual string PostalCode { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public virtual string StateProvinceName { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public virtual string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public virtual string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fdb9bd73a26f764949d70eeba70b0602</Hash>
</Codenesium>*/