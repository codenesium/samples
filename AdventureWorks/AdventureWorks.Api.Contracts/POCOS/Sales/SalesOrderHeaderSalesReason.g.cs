using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderHeaderSalesReason
	{
		public POCOSalesOrderHeaderSalesReason()
		{}

		public POCOSalesOrderHeaderSalesReason(int salesOrderID,
		                                       int salesReasonID,
		                                       DateTime modifiedDate)
		{
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int SalesOrderID {get; set;}
		public int SalesReasonID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue {get; set;} = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue {get; set;} = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return ShouldSerializeSalesReasonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>1d88e9db044b48193089b05267a219ae</Hash>
</Codenesium>*/