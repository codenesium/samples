using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonPhone", Schema="Person")]
	public partial class EFPersonPhone: AbstractEntityFrameworkPOCO
	{
		public EFPersonPhone()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber.ToString();
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PhoneNumber", TypeName="nvarchar(25)")]
		public string PhoneNumber { get; set; }

		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }

		[ForeignKey("PhoneNumberTypeID")]
		public virtual EFPhoneNumberType PhoneNumberType { get; set; }
	}
}

/*<Codenesium>
    <Hash>a0375b6db73171f44b67bfafb8bd5900</Hash>
</Codenesium>*/