using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CreditCard", Schema="Sales")]
	public partial class EFCreditCard: AbstractEntityFrameworkPOCO
	{
		public EFCreditCard()
		{}

		public void SetProperties(
			int creditCardID,
			string cardType,
			string cardNumber,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CreditCardID = creditCardID.ToInt();
			this.CardType = cardType.ToString();
			this.CardNumber = cardNumber.ToString();
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; set; }

		[Column("CardType", TypeName="nvarchar(50)")]
		public string CardType { get; set; }

		[Column("CardNumber", TypeName="nvarchar(25)")]
		public string CardNumber { get; set; }

		[Column("ExpMonth", TypeName="tinyint")]
		public int ExpMonth { get; set; }

		[Column("ExpYear", TypeName="smallint")]
		public short ExpYear { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>2521b532c73694b10317c301f4e8b9c9</Hash>
</Codenesium>*/