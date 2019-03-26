using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonPhone", Schema="Person")]
	public partial class PersonPhone : AbstractEntity
	{
		public PersonPhone()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[MaxLength(25)]
		[Column("PhoneNumber")]
		public virtual string PhoneNumber { get; private set; }

		[Key]
		[Column("PhoneNumberTypeID")]
		public virtual int PhoneNumberTypeID { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual Person BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(Person item)
		{
			this.BusinessEntityIDNavigation = item;
		}

		[ForeignKey("PhoneNumberTypeID")]
		public virtual PhoneNumberType PhoneNumberTypeIDNavigation { get; private set; }

		public void SetPhoneNumberTypeIDNavigation(PhoneNumberType item)
		{
			this.PhoneNumberTypeIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>149af0e3ecdc269c22700aa8d28c4429</Hash>
</Codenesium>*/