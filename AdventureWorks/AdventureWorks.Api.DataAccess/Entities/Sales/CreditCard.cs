using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CreditCard", Schema="Sales")]
	public partial class CreditCard: AbstractEntity
	{
		public CreditCard()
		{}

		public void SetProperties(
			string cardNumber,
			string cardType,
			int creditCardID,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber;
			this.CardType = cardType;
			this.CreditCardID = creditCardID.ToInt();
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Column("CardNumber", TypeName="nvarchar(25)")]
		public string CardNumber { get; private set; }

		[Column("CardType", TypeName="nvarchar(50)")]
		public string CardType { get; private set; }

		[Key]
		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; private set; }

		[Column("ExpMonth", TypeName="tinyint")]
		public int ExpMonth { get; private set; }

		[Column("ExpYear", TypeName="smallint")]
		public short ExpYear { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b62485a7c728d502483a2d0dcb756333</Hash>
</Codenesium>*/