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

		public PersonCreditCardModel(
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
    <Hash>0c1b136b2bffbb5d002922426fe67f53</Hash>
</Codenesium>*/