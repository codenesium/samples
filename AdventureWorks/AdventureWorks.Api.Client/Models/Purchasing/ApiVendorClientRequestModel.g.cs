using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiVendorClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVendorClientRequestModel()
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

		[JsonProperty]
		public string AccountNumber { get; private set; } = default(string);

		[JsonProperty]
		public bool ActiveFlag { get; private set; } = default(bool);

		[JsonProperty]
		public int CreditRating { get; private set; } = default(int);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public bool PreferredVendorStatu { get; private set; } = default(bool);

		[JsonProperty]
		public string PurchasingWebServiceURL { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>af7f1cd30bd7a2dff34a2d25ed23f8a2</Hash>
</Codenesium>*/