using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class EFPersonCreditCard
	{
		public EFPersonCreditCard()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public int CreditCardID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
		[ForeignKey("CreditCardID")]
		public virtual EFCreditCard CreditCardRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>dc414c3bfa2e41886e4134027083bcec</Hash>
</Codenesium>*/