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
			int creditCardID,
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CreditCardID = creditCardID;
			this.CardNumber = cardNumber;
			this.CardType = cardType;
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
    <Hash>2f7f8fcef46af6aecb2b3ec85948fd36</Hash>
</Codenesium>*/