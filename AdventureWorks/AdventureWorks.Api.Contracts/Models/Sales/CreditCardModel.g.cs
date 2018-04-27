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
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber.ToString();
			this.CardType = cardType.ToString();
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>9d44e6f226a458e9e7cefed8e65575d6</Hash>
</Codenesium>*/