using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductListPriceHistory: AbstractBusinessObject
        {
                public BOProductListPriceHistory() : base()
                {
                }

                public void SetProperties(int productID,
                                          Nullable<DateTime> endDate,
                                          decimal listPrice,
                                          DateTime modifiedDate,
                                          DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StartDate = startDate;
                }

                public Nullable<DateTime> EndDate { get; private set; }

                public decimal ListPrice { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5a23b69a2062bd28074e216586fa7340</Hash>
</Codenesium>*/