using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOScrapReason: AbstractBusinessObject
	{
		public BOScrapReason() : base()
		{}

		public void SetProperties(short scrapReasonID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ScrapReasonID = scrapReasonID;
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>22d4382b8882f6929a7217610f87bb1d</Hash>
</Codenesium>*/