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
		public virtual string CardNumber { get; private set; }

		[MaxLength(50)]
		[Column("CardType")]
		public virtual string CardType { get; private set; }

		[Key]
		[Column("CreditCardID")]
		public virtual int CreditCardID { get; private set; }

		[Column("ExpMonth")]
		public virtual int ExpMonth { get; private set; }

		[Column("ExpYear")]
		public virtual short ExpYear { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>654a45ced1a74b2600b06fbc44ead5ce</Hash>
</Codenesium>*/