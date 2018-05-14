using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonCreditCardModel
	{
		public ApiPersonCreditCardModel()
		{}

		public ApiPersonCreditCardModel(
			int creditCardID,
			DateTime modifiedDate)
		{
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int creditCardID;

		[Required]
		public int CreditCardID
		{
			get
			{
				return this.creditCardID;
			}

			set
			{
				this.creditCardID = value;
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
    <Hash>dfb395495441919f5b3253ec92e026ed</Hash>
</Codenesium>*/