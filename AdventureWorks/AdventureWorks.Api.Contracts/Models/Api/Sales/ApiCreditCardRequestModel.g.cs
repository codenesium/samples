using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCreditCardRequestModel : AbstractApiRequestModel
	{
		public ApiCreditCardRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber;
			this.CardType = cardType;
			this.ExpMonth = expMonth;
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate;
		}

		[Required]
		[JsonProperty]
		public string CardNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string CardType { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ExpMonth { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public short ExpYear { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>830730433c0822a42b1bf6a040a488a3</Hash>
</Codenesium>*/