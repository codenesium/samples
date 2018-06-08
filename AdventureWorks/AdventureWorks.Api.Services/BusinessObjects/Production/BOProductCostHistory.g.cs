using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductCostHistory: AbstractBusinessObject
        {
                public BOProductCostHistory() : base()
                {
                }

                public void SetProperties(int productID,
                                          Nullable<DateTime> endDate,
                                          DateTime modifiedDate,
                                          decimal standardCost,
                                          DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StandardCost = standardCost;
                        this.StartDate = startDate;
                }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public decimal StandardCost { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4b5df94cd49f659373974a39df8cdfc5</Hash>
</Codenesium>*/