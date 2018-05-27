using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOVendor: AbstractDTO
	{
		public DTOVendor() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          string accountNumber,
		                          bool activeFlag,
		                          int creditRating,
		                          DateTime modifiedDate,
		                          string name,
		                          bool preferredVendorStatus,
		                          string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber;
			this.ActiveFlag = activeFlag.ToBoolean();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditRating = creditRating.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
		}

		public string AccountNumber { get; set; }
		public bool ActiveFlag { get; set; }
		public int BusinessEntityID { get; set; }
		public int CreditRating { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public bool PreferredVendorStatus { get; set; }
		public string PurchasingWebServiceURL { get; set; }
	}
}

/*<Codenesium>
    <Hash>1ea90b8c7b52dbfcb0f47d45fc429dab</Hash>
</Codenesium>*/