using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiVendorClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			string accountNumber,
			bool activeFlag,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatu,
			string purchasingWebServiceURL)
		{
			this.BusinessEntityID = businessEntityID;
			this.AccountNumber = accountNumber;
			this.ActiveFlag = activeFlag;
			this.CreditRating = creditRating;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.PreferredVendorStatu = preferredVendorStatu;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
		}

		[JsonProperty]
		public string AccountNumber { get; private set; }

		[JsonProperty]
		public bool ActiveFlag { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public int CreditRating { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public bool PreferredVendorStatu { get; private set; }

		[JsonProperty]
		public string PurchasingWebServiceURL { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e7c311b8eab01737e36f825eaec916c3</Hash>
</Codenesium>*/