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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }
		[ForeignKey("CreditCardID")]
		public virtual EFCreditCard CreditCard { get; set; }
	}
}

/*<Codenesium>
    <Hash>f6fe80d0941977ad717a6b758ffaab40</Hash>
</Codenesium>*/