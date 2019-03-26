using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiVendorServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string PurchasingWebServiceURL { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0e7831507f6bb4eac6da1ea2480d004a</Hash>
</Codenesium>*/