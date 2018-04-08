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
			this.ModifiedDate = modifiedDate.ToDateTime();

			SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                        "SalesOrderHeader");
			SalesReasonID = new ReferenceEntity<int>(salesReasonID,
			                                         "SalesReason");
		}

		public ReferenceEntity<int>SalesOrderID {get; set;}
		public ReferenceEntity<int>SalesReasonID {get; set;}
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
    <Hash>f2c05aaf607f827701f31a7aa6a02720</Hash>
</Codenesium>*/