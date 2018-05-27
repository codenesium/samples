using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPersonCreditCard: AbstractDTO
	{
		public DTOPersonCreditCard() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          int creditCardID,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID { get; set; }
		public int CreditCardID { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>8c8b075e77fe11fedebd64ff1ad92936</Hash>
</Codenesium>*/