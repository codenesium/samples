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
    <Hash>7f6ade8e53ce308ec25dcb7b29d3d386</Hash>
</Codenesium>*/