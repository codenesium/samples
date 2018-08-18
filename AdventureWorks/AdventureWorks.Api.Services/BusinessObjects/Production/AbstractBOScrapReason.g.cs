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
    <Hash>4ec4f1340d8e9525712680b993d7b948</Hash>
</Codenesium>*/