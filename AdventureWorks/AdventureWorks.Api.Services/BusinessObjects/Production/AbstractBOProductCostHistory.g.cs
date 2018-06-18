using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductCostHistory: AbstractBusinessObject
        {
                public AbstractBOProductCostHistory() : base()
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
    <Hash>f27a87c12bd49c0fd20ccf35ce5a3eb4</Hash>
</Codenesium>*/