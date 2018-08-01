using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOScrapReason : AbstractBusinessObject
	{
		public AbstractBOScrapReason()
			: base()
		{
		}

		public virtual void SetProperties(short scrapReasonID,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ScrapReasonID = scrapReasonID;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9cd876dc424ed71f670d69ab2137eb00</Hash>
</Codenesium>*/