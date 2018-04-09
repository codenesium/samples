using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class EFPersonCreditCard
	{
		public EFPersonCreditCard()
		{}

		public void SetProperties(int businessEntityID,
		                          int creditCardID,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }

		public virtual EFCreditCard CreditCard { get; set; }
	}
}

/*<Codenesium>
    <Hash>a2fe19974360ee65c1442973361ab87b</Hash>
</Codenesium>*/