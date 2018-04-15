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

		public CreditCardModel(
			string cardType,
			string cardNumber,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardType = cardType.ToString();
			this.CardNumber = cardNumber.ToString();
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string cardType;

		[Required]
		public string CardType
		{
			get
			{
				return this.cardType;
			}

			set
			{
				this.cardType = value;
			}
		}

		private string cardNumber;

		[Required]
		public string CardNumber
		{
			get
			{
				return this.cardNumber;
			}

			set
			{
				this.cardNumber = value;
			}
		}

		private int expMonth;

		[Required]
		public int ExpMonth
		{
			get
			{
				return this.expMonth;
			}

			set
			{
				this.expMonth = value;
			}
		}

		private short expYear;

		[Required]
		public short ExpYear
		{
			get
			{
				return this.expYear;
			}

			set
			{
				this.expYear = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ec0f1fffd8b8088f0104f6670858c485</Hash>
</Codenesium>*/