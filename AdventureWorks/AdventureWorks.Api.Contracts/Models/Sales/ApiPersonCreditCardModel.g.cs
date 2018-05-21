using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonCreditCardModel: AbstractModel
	{
		public ApiPersonCreditCardModel() : base()
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
    <Hash>8cc18db8d3b400bb24f278e4dfd3ebcb</Hash>
</Codenesium>*/