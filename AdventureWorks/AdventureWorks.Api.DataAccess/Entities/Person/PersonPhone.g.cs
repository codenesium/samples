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
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[MaxLength(25)]
		[Column("PhoneNumber")]
		public string PhoneNumber { get; private set; }

		[Key]
		[Column("PhoneNumberTypeID")]
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cbb6c0df82ebaa0753c8c39d93f51cde</Hash>
</Codenesium>*/