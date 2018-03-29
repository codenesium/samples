using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PersonCreditCardModel
	{
		public PersonCreditCardModel()
		{}

		public PersonCreditCardModel(int creditCardID,
		                             DateTime modifiedDate)
		{
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public PersonCreditCardModel(POCOPersonCreditCard poco)
		{
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.CreditCardID = poco.CreditCardID.Value.ToInt();
		}

		private int _creditCardID;
		[Required]
		public int CreditCardID
		{
			get
			{
				return _creditCardID;
			}
			set
			{
				this._creditCardID = value;
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
    <Hash>7601d70ff8aa833644a6f189261f122d</Hash>
</Codenesium>*/