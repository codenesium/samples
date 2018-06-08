using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSalesOrderHeaderSalesReason: AbstractBusinessObject
        {
                public BOSalesOrderHeaderSalesReason() : base()
                {
                }

                public void SetProperties(int salesOrderID,
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
    <Hash>6d0c875fb63506f8450f8bd59c7b4c74</Hash>
</Codenesium>*/