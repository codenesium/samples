using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSalesReason: AbstractBusinessObject
        {
                public BOSalesReason() : base()
                {
                }

                public void SetProperties(int salesReasonID,
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
    <Hash>1aa6afbb1faf696de8f3df9d03740641</Hash>
</Codenesium>*/