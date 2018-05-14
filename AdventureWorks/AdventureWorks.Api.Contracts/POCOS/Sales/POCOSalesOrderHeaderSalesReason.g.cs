using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderHeaderSalesReason
	{
		public POCOSalesOrderHeaderSalesReason()
		{}

		public POCOSalesOrderHeaderSalesReason(
			DateTime modifiedDate,
			int salesOrderID,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                             nameof(ApiResponse.SalesOrderHeaders));
			this.SalesReasonID = new ReferenceEntity<int>(salesReasonID,
			                                              nameof(ApiResponse.SalesReasons));
		}

		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> SalesOrderID { get; set; }
		public ReferenceEntity<int> SalesReasonID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return this.ShouldSerializeSalesReasonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesReasonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>cc9dadb09e8e6ec26592742c4dd024d1</Hash>
</Codenesium>*/