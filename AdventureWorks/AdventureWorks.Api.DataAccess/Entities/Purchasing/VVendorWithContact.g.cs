using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vVendorWithContacts", Schema="Purchasing")]
	public partial class VVendorWithContact : AbstractEntity
	{
		public VVendorWithContact()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string contactType,
			string emailAddress,
			int emailPromotion,
			string firstName,
			string lastName,
			string middleName,
			string name,
			string phoneNumber,
			string phoneNumberType,
			string suffix,
			string title)
		{
			this.BusinessEntityID = businessEntityID;
			this.ContactType = contactType;
			this.EmailAddress = emailAddress;
			this.EmailPromotion = emailPromotion;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.Name = name;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberType = phoneNumberType;
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("ContactType")]
		public virtual string ContactType { get; private set; }

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

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[MaxLength(25)]
		[Column("PhoneNumber")]
		public virtual string PhoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("PhoneNumberType")]
		public virtual string PhoneNumberType { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public virtual string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public virtual string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bd2086ace2f10ba727f70cac89c62e63</Hash>
</Codenesium>*/