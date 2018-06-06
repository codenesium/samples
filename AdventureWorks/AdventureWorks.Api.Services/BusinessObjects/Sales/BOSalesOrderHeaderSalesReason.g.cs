using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>d9fdf2996f5f43db59b9f0d5e8de2625</Hash>
</Codenesium>*/