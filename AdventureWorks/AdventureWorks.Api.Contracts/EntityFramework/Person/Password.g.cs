using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Password", Schema="Person")]
	public partial class EFPassword
	{
		public EFPassword()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public string PasswordHash {get; set;}
		public string PasswordSalt {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>dd7fd94102b5169ca5fe75a07f9c3acd</Hash>
</Codenesium>*/