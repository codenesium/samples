using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCreditCardServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCreditCardServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>eb58410b466a94660892ee8bd7f837a1</Hash>
</Codenesium>*/