using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>1845b74d2ca5749b0d898970926b6836</Hash>
</Codenesium>*/