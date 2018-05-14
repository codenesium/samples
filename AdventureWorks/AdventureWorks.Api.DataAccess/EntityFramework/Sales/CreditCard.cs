using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CreditCard", Schema="Sales")]
	public partial class CreditCard: AbstractEntityFrameworkPOCO
	{
		public CreditCard()
		{}

		public void SetProperties(
			int creditCardID,
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber.ToString();
			this.CardType = cardType.ToString();
			this.CreditCardID = creditCardID.ToInt();
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Column("CardNumber", TypeName="nvarchar(25)")]
		public string CardNumber { get; set; }

		[Column("CardType", TypeName="nvarchar(50)")]
		public string CardType { get; set; }

		[Key]
		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; set; }

		[Column("ExpMonth", TypeName="tinyint")]
		public int ExpMonth { get; set; }

		[Column("ExpYear", TypeName="smallint")]
		public short ExpYear { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>0ad33804b41e752f3835ee840b9e7984</Hash>
</Codenesium>*/