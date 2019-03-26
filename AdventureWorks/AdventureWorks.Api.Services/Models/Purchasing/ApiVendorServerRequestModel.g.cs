using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiVendorServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVendorServerRequestModel()
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
		public string AccountNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool ActiveFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public int CreditRating { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool PreferredVendorStatu { get; private set; } = default(bool);

		[JsonProperty]
		public string PurchasingWebServiceURL { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4fa247cbac121bbccb82580374ad224c</Hash>
</Codenesium>*/