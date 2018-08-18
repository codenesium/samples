using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVendorRequestModel : AbstractApiRequestModel
	{
		public ApiVendorRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string accountNumber,
			bool activeFlag,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatu,
			string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber;
			this.ActiveFlag = activeFlag;
			this.CreditRating = creditRating;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.PreferredVendorStatu = preferredVendorStatu;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
		}

		[Required]
		[JsonProperty]
		public string AccountNumber { get; private set; }

		[Required]
		[JsonProperty]
		public bool ActiveFlag { get; private set; }

		[Required]
		[JsonProperty]
		public int CreditRating { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public bool PreferredVendorStatu { get; private set; }

		[JsonProperty]
		public string PurchasingWebServiceURL { get; private set; }
	}
}

/*<Codenesium>
    <Hash>276656e633200286f8ecc64eaec508ad</Hash>
</Codenesium>*/