using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonCreditCardRequestModel: AbstractApiRequestModel
	{
		public ApiPersonCreditCardRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>8784ac2b405aa8a0c9205eb694229916</Hash>
</Codenesium>*/