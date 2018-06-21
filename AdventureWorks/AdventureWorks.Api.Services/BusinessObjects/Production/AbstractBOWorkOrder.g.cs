using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOWorkOrder : AbstractBusinessObject
        {
                public AbstractBOWorkOrder()
                        : base()
                {
                }

                public virtual void SetProperties(int workOrderID,
                                                  DateTime dueDate,
                                                  Nullable<DateTime> endDate,
                                                  DateTime modifiedDate,
                                                  int orderQty,
                                                  int productID,
                                                  short scrappedQty,
                                                  Nullable<short> scrapReasonID,
                                                  DateTime startDate,
                                                  int stockedQty)
                {
                        this.DueDate = dueDate;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.ScrappedQty = scrappedQty;
                        this.ScrapReasonID = scrapReasonID;
                        this.StartDate = startDate;
                        this.StockedQty = stockedQty;
                        this.WorkOrderID = workOrderID;
                }

                public DateTime DueDate { get; private set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int OrderQty { get; private set; }

                public int ProductID { get; private set; }

                public short ScrappedQty { get; private set; }

                public Nullable<short> ScrapReasonID { get; private set; }

                public DateTime StartDate { get; private set; }

                public int StockedQty { get; private set; }

                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>330de40a714683ec089c5a0061320947</Hash>
</Codenesium>*/