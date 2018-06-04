using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonPhone", Schema="Person")]
	public partial class PersonPhone: AbstractEntity
	{
		public PersonPhone()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PhoneNumber", TypeName="nvarchar(25)")]
		public string PhoneNumber { get; private set; }

		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8c7cbd06ef00a64bcd6490e387a331a2</Hash>
</Codenesium>*/