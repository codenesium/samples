using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EFEmailAddress
	{
		public EFEmailAddress()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public int EmailAddressID {get; set;}
		public string EmailAddress1 {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>1b5aec8791642de61c0c6958526486ab</Hash>
</Codenesium>*/