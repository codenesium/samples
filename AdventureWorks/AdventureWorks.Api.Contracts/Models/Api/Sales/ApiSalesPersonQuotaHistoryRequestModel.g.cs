using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesPersonQuotaHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiSalesPersonQuotaHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.ModifiedDate = modifiedDate;
			this.QuotaDate = quotaDate;
			this.Rowguid = rowguid;
			this.SalesQuota = salesQuota;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime QuotaDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public decimal SalesQuota { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>feb1019a48ae16a1e2f0a723585aa6a5</Hash>
</Codenesium>*/