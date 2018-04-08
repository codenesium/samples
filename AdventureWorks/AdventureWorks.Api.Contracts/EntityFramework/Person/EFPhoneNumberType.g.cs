using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PhoneNumberType", Schema="Person")]
	public partial class EFPhoneNumberType
	{
		public EFPhoneNumberType()
		{}

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
    <Hash>3ffd41a0aca88256568e07d0e61d6473</Hash>
</Codenesium>*/