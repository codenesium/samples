using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCreditCard
	{
		public POCOCreditCard()
		{}

		public POCOCreditCard(int creditCardID,
		                      string cardType,
		                      string cardNumber,
		                      int expMonth,
		                      short expYear,
		                      DateTime modifiedDate)
		{
			this.CreditCardID = creditCardID.ToInt();
			this.CardType = cardType;
			this.CardNumber = cardNumber;
			this.ExpMonth = expMonth;
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int CreditCardID {get; set;}
		public string CardType {get; set;}
		public string CardNumber {get; set;}
		public int ExpMonth {get; set;}
		public short ExpYear {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue {get; set;} = true;

		public bool ShouldSerializeCreditCardID()
		{
			return ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCardTypeValue {get; set;} = true;

		public bool ShouldSerializeCardType()
		{
			return ShouldSerializeCardTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCardNumberValue {get; set;} = true;

		public bool ShouldSerializeCardNumber()
		{
			return ShouldSerializeCardNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExpMonthValue {get; set;} = true;

		public bool ShouldSerializeExpMonth()
		{
			return ShouldSerializeExpMonthValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExpYearValue {get; set;} = true;

		public bool ShouldSerializeExpYear()
		{
			return ShouldSerializeExpYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeCardTypeValue = false;
			this.ShouldSerializeCardNumberValue = false;
			this.ShouldSerializeExpMonthValue = false;
			this.ShouldSerializeExpYearValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7f4b67008ce92d594ee4e129d40cf144</Hash>
</Codenesium>*/