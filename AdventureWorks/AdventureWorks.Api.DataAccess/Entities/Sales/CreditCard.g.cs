using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CreditCard", Schema="Sales")]
	public partial class CreditCard : AbstractEntity
	{
		public CreditCard()
		{
		}

		public virtual void SetProperties(
			string cardNumber,
			string cardType,
			int creditCardID,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber;
			this.CardType = cardType;
			this.CreditCardID = creditCardID;
			this.ExpMonth = expMonth;
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate;
		}

		[MaxLength(25)]
		[Column("CardNumber")]
		public string CardNumber { get; private set; }

		[MaxLength(50)]
		[Column("CardType")]
		public string CardType { get; private set; }

		[Key]
		[Column("CreditCardID")]
		public int CreditCardID { get; private set; }

		[Column("ExpMonth")]
		public int ExpMonth { get; private set; }

		[Column("ExpYear")]
		public short ExpYear { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>08eeaf3037f02d4a7ea37fd09b6ad88f</Hash>
</Codenesium>*/