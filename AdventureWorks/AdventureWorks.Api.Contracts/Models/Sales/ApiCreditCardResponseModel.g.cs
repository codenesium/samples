using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCreditCardResponseModel: AbstractApiResponseModel
	{
		public ApiCreditCardResponseModel() : base()
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

		public string CardNumber { get; set; }
		public string CardType { get; set; }
		public int CreditCardID { get; set; }
		public int ExpMonth { get; set; }
		public short ExpYear { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCardNumberValue { get; set; } = true;

		public bool ShouldSerializeCardNumber()
		{
			return this.ShouldSerializeCardNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCardTypeValue { get; set; } = true;

		public bool ShouldSerializeCardType()
		{
			return this.ShouldSerializeCardTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

		public bool ShouldSerializeCreditCardID()
		{
			return this.ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExpMonthValue { get; set; } = true;

		public bool ShouldSerializeExpMonth()
		{
			return this.ShouldSerializeExpMonthValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExpYearValue { get; set; } = true;

		public bool ShouldSerializeExpYear()
		{
			return this.ShouldSerializeExpYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCardNumberValue = false;
			this.ShouldSerializeCardTypeValue = false;
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeExpMonthValue = false;
			this.ShouldSerializeExpYearValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7469d7d2ebac453e9132470e6ecd91bd</Hash>
</Codenesium>*/