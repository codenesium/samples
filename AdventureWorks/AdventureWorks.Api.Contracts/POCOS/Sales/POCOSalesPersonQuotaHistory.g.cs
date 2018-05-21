using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesPersonQuotaHistory: AbstractPOCO
	{
		public POCOSalesPersonQuotaHistory() : base()
		{}

		public POCOSalesPersonQuotaHistory(
			int businessEntityID,
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.QuotaDate = quotaDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesQuota = salesQuota.ToDecimal();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.SalesPersons));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime QuotaDate { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesQuota { get; set; }

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
    <Hash>f7256b51c6476ccae5b9019de0162c08</Hash>
</Codenesium>*/