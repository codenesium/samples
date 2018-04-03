using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class CreditCardModel
	{
		public CreditCardModel()
		{}
		public CreditCardModel(string cardType,
		                       string cardNumber,
		                       int expMonth,
		                       short expYear,
		                       DateTime modifiedDate)
		{
			this.CardType = cardType;
			this.CardNumber = cardNumber;
			this.ExpMonth = expMonth;
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _cardType;
		[Required]
		public string CardType
		{
			get
			{
				return _cardType;
			}
			set
			{
				this._cardType = value;
			}
		}

		private string _cardNumber;
		[Required]
		public string CardNumber
		{
			get
			{
				return _cardNumber;
			}
			set
			{
				this._cardNumber = value;
			}
		}

		private int _expMonth;
		[Required]
		public int ExpMonth
		{
			get
			{
				return _expMonth;
			}
			set
			{
				this._expMonth = value;
			}
		}

		private short _expYear;
		[Required]
		public short ExpYear
		{
			get
			{
				return _expYear;
			}
			set
			{
				this._expYear = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a675bf707f8557195cf35272515f5409</Hash>
</Codenesium>*/