using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>16e0ac047258e9505e25195ceedc99bd</Hash>
</Codenesium>*/