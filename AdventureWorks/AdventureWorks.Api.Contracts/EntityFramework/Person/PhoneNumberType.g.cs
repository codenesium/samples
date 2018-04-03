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
		public int phoneNumberTypeID {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>938ff59492a743473187c02e02c5f59e</Hash>
</Codenesium>*/