using Codenesium.DataConversionExtensions;
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
    <Hash>a78b39f3b3a4cd7a6a4e04d25a3b30a8</Hash>
</Codenesium>*/