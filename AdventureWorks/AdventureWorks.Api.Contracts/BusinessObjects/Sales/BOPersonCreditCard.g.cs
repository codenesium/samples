using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOPersonCreditCard: AbstractBusinessObject
	{
		public BOPersonCreditCard() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          int creditCardID,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID { get; private set; }
		public int CreditCardID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4ece1c450b0b2a03022f642e09a4d29b</Hash>
</Codenesium>*/