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
			int salesOrderID,
			int salesReasonID,
			DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                             nameof(ApiResponse.SalesOrderHeaders));
			this.SalesReasonID = new ReferenceEntity<int>(salesReasonID,
			                                              nameof(ApiResponse.SalesReasons));
		}

		public ReferenceEntity<int> SalesOrderID { get; set; }
		public ReferenceEntity<int> SalesReasonID { get; set; }
		public DateTime ModifiedDate { get; set; }

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

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesReasonIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ee9cccdef64c3900de234e6597ff7683</Hash>
</Codenesium>*/