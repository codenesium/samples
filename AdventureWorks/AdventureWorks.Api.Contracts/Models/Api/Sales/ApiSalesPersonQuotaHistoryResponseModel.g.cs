using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesPersonQuotaHistoryResponseModel: AbstractApiResponseModel
	{
		public ApiSalesPersonQuotaHistoryResponseModel() : base()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.QuotaDate = quotaDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesQuota = salesQuota.ToDecimal();

			this.BusinessEntityIDEntity = nameof(ApiResponse.SalesPersons);
		}

		public int BusinessEntityID { get; private set; }
		public string BusinessEntityIDEntity { get; set; }
		public DateTime ModifiedDate { get; private set; }
		public DateTime QuotaDate { get; private set; }
		public Guid Rowguid { get; private set; }
		public decimal SalesQuota { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuotaDateValue { get; set; } = true;

		public bool ShouldSerializeQuotaDate()
		{
			return this.ShouldSerializeQuotaDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesQuotaValue { get; set; } = true;

		public bool ShouldSerializeSalesQuota()
		{
			return this.ShouldSerializeSalesQuotaValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeQuotaDateValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesQuotaValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e10d27e295fc7e5db0a9fa680aeb5940</Hash>
</Codenesium>*/