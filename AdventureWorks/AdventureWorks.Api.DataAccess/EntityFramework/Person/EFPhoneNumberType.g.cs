using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PhoneNumberType", Schema="Person")]
	public partial class EFPhoneNumberType: AbstractEntityFrameworkPOCO
	{
		public EFPhoneNumberType()
		{}

		public void SetProperties(
			int phoneNumberTypeID,
			string name,
			DateTime modifiedDate)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>96001479ce42185fc00a31ea002ef034</Hash>
</Codenesium>*/