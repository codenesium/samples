using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCreditCardClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCreditCardClientRequestModel()
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

		[JsonProperty]
		public string CardNumber { get; private set; } = default(string);

		[JsonProperty]
		public string CardType { get; private set; } = default(string);

		[JsonProperty]
		public int ExpMonth { get; private set; } = default(int);

		[JsonProperty]
		public short ExpYear { get; private set; } = default(short);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>4d6e12eec6da3db10ea2892c24830216</Hash>
</Codenesium>*/