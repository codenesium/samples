using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesOrderHeaderSalesReason: AbstractDTO
	{
		public DTOSalesOrderHeaderSalesReason() : base()
		{}

		public void SetProperties(int salesOrderID,
		                          DateTime modifiedDate,
		                          int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public int SalesOrderID { get; set; }
		public int SalesReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>6b5192688599ec05e1b8518f3bc16a17</Hash>
</Codenesium>*/