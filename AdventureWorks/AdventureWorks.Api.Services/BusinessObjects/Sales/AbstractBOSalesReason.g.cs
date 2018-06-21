using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesReason : AbstractBusinessObject
        {
                public AbstractBOSalesReason()
                        : base()
                {
                }

                public virtual void SetProperties(int salesReasonID,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  string reasonType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                        this.SalesReasonID = salesReasonID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string ReasonType { get; private set; }

                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c9719f5d2ea915bfccaa6c3cd1bf27b6</Hash>
</Codenesium>*/