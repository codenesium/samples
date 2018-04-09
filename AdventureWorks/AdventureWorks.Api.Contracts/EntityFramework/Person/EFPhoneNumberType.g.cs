using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PhoneNumberType", Schema="Person")]
	public partial class EFPhoneNumberType
	{
		public EFPhoneNumberType()
		{}

		public void SetProperties(int phoneNumberTypeID,
		                          string name,
		                          DateTime modifiedDate)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3970235c0d8c58ec78527e463234e2b3</Hash>
</Codenesium>*/