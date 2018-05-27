using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCreditCard: AbstractDTO
	{
		public DTOCreditCard() : base()
		{}

		public void SetProperties(int creditCardID,
		                          string cardNumber,
		                          string cardType,
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

		public string CardNumber { get; set; }
		public string CardType { get; set; }
		public int CreditCardID { get; set; }
		public int ExpMonth { get; set; }
		public short ExpYear { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>7c796dcfa9e2a7255d07f9770782b050</Hash>
</Codenesium>*/