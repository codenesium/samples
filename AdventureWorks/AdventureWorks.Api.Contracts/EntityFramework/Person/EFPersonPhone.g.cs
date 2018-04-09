using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonPhone", Schema="Person")]
	public partial class EFPersonPhone
	{
		public EFPersonPhone()
		{}

		public void SetProperties(int businessEntityID,
		                          string phoneNumber,
		                          int phoneNumberTypeID,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("PhoneNumber", TypeName="nvarchar(25)")]
		public string PhoneNumber {get; set;}

		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }

		public virtual EFPhoneNumberType PhoneNumberType { get; set; }
	}
}

/*<Codenesium>
    <Hash>3f6e990e307994b4669891bbf2f112ca</Hash>
</Codenesium>*/