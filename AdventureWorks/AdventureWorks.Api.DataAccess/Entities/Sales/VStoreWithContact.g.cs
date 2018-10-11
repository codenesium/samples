using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vStoreWithContacts", Schema="Sales")]
	public partial class VStoreWithContact : AbstractEntity
	{
		public VStoreWithContact()
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
		public int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("ContactType")]
		public string ContactType { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public string EmailAddress { get; private set; }

		[Column("EmailPromotion")]
		public int EmailPromotion { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public string MiddleName { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(25)]
		[Column("PhoneNumber")]
		public string PhoneNumber { get; private set; }

		[MaxLength(50)]
		[Column("PhoneNumberType")]
		public string PhoneNumberType { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>13cdd00d20882093e437ca0731317b54</Hash>
</Codenesium>*/