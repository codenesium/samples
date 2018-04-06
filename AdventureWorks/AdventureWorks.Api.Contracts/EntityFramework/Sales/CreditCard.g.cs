using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CreditCard", Schema="Sales")]
	public partial class EFCreditCard
	{
		public EFCreditCard()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID {get; set;}
		[Column("CardType", TypeName="nvarchar(50)")]
		public string CardType {get; set;}
		[Column("CardNumber", TypeName="nvarchar(25)")]
		public string CardNumber {get; set;}
		[Column("ExpMonth", TypeName="tinyint")]
		public int ExpMonth {get; set;}
		[Column("ExpYear", TypeName="smallint")]
		public short ExpYear {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>5fe6bdd812d26fa1ea3cb9c185e48185</Hash>
</Codenesium>*/