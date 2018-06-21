using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesOrderHeaderSalesReason : AbstractBusinessObject
        {
                public AbstractBOSalesOrderHeaderSalesReason()
                        : base()
                {
                }

                public virtual void SetProperties(int salesOrderID,
                                                  DateTime modifiedDate,
                                                  int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.SalesOrderID = salesOrderID;
                        this.SalesReasonID = salesReasonID;
                }

                public DateTime ModifiedDate { get; private set; }

                public int SalesOrderID { get; private set; }

                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6527173c505fd29f742cfc346ecfde8f</Hash>
</Codenesium>*/