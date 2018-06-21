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
    <Hash>2e62593eb3dc70afcb902e86b47c120f</Hash>
</Codenesium>*/