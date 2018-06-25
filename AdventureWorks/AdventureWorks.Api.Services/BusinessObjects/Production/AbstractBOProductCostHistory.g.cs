using Codenesium.DataConversionExtensions;
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
                                                  DateTime? endDate,
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

                public DateTime? EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public decimal StandardCost { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d64e06e06ad9ba10dcd09deba8fdac9f</Hash>
</Codenesium>*/