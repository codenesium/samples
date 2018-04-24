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
			string phoneNumber,
			int phoneNumberTypeID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PhoneNumber = phoneNumber.ToString();
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("PhoneNumber", TypeName="nvarchar(25)")]
		public string PhoneNumber { get; set; }

		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }

		[ForeignKey("PhoneNumberTypeID")]
		public virtual EFPhoneNumberType PhoneNumberType { get; set; }
	}
}

/*<Codenesium>
    <Hash>62f59afc490265b39d4922a2725e15c6</Hash>
</Codenesium>*/