using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCreditCardResponseModel : AbstractApiResponseModel
	{
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

		[JsonProperty]
		public string CardNumber { get; private set; }

		[JsonProperty]
		public string CardType { get; private set; }

		[JsonProperty]
		public int CreditCardID { get; private set; }

		[JsonProperty]
		public int ExpMonth { get; private set; }

		[JsonProperty]
		public short ExpYear { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3334775ca43551c7b7df7fb0b5ba88d3</Hash>
</Codenesium>*/