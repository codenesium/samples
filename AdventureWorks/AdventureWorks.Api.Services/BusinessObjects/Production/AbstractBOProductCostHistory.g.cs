using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductCostHistory : AbstractBusinessObject
        {
                public AbstractBOProductCostHistory()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
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
    <Hash>3ff4b5148004f4fd2424ec0bc3f65c5a</Hash>
</Codenesium>*/