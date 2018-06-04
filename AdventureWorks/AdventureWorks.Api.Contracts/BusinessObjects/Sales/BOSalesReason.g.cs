using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>069ee906a03b502903b4ceacc9fcb618</Hash>
</Codenesium>*/