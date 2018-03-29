using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonPhone", Schema="Person")]
	public partial class EFPersonPhone
	{
		public EFPersonPhone()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public string PhoneNumber {get; set;}
		public int PhoneNumberTypeID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
		[ForeignKey("PhoneNumberTypeID")]
		public virtual EFPhoneNumberType PhoneNumberTypeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>1a7aee4c614a7ebf1d2c3733e844654d</Hash>
</Codenesium>*/