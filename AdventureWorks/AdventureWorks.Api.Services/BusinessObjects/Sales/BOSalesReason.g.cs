using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSalesReason: AbstractBusinessObject
	{
		public BOSalesReason() : base()
		{}

		public void SetProperties(int salesReasonID,
		                          DateTime modifiedDate,
		                          string name,
		                          string reasonType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ReasonType = reasonType;
			this.SalesReasonID = salesReasonID.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public string ReasonType { get; private set; }
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5cb7f44fc8599ac787c079f7eb0b9082</Hash>
</Codenesium>*/