using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesPersonQuotaHistory
	{
		public POCOSalesPersonQuotaHistory()
		{}

		public POCOSalesPersonQuotaHistory(int businessEntityID,
		                                   DateTime quotaDate,
		                                   decimal salesQuota,
		                                   Guid rowguid,
		                                   DateTime modifiedDate)
		{
			this.QuotaDate = quotaDate.ToDateTime();
			this.SalesQuota = salesQuota;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "SalesPerson");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public DateTime QuotaDate {get; set;}
		public decimal SalesQuota {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuotaDateValue {get; set;} = true;

		public bool ShouldSerializeQuotaDate()
		{
			return ShouldSerializeQuotaDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesQuotaValue {get; set;} = true;

		public bool ShouldSerializeSalesQuota()
		{
			return ShouldSerializeSalesQuotaValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeQuotaDateValue = false;
			this.ShouldSerializeSalesQuotaValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>58886c0ed6cf17ad8d1e9c2e0b91bb30</Hash>
</Codenesium>*/