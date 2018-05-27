using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesReason: AbstractDTO
	{
		public DTOSalesReason() : base()
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

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public string ReasonType { get; set; }
		public int SalesReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>508707070fc13ede22d15ac4723888c5</Hash>
</Codenesium>*/