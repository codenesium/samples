using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOScrapReason: AbstractBusinessObject
        {
                public AbstractBOScrapReason() : base()
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
    <Hash>38167b1ffdb0491b584609010bbb29bc</Hash>
</Codenesium>*/