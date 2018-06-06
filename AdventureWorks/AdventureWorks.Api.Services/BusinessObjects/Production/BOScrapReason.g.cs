using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>429615ca8498e94765cc9493b49c62f5</Hash>
</Codenesium>*/