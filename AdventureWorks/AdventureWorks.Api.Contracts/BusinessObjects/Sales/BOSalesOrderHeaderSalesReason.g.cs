using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOSalesOrderHeaderSalesReason: AbstractBusinessObject
	{
		public BOSalesOrderHeaderSalesReason() : base()
		{}

		public void SetProperties(int salesOrderID,
		                          DateTime modifiedDate,
		                          int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public int SalesOrderID { get; private set; }
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2029e9a2f3e5cfac8efa28c6d1e82055</Hash>
</Codenesium>*/