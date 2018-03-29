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
		public int PhoneNumberTypeID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>269bd709f4a315b3b24a99bc1ce0b777</Hash>
</Codenesium>*/