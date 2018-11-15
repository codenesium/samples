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
	}
}

/*<Codenesium>
    <Hash>278bfe176e2e786f7b75075ee74c4a35</Hash>
</Codenesium>*/