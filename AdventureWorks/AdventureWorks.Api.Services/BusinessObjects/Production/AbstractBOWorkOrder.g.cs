using Codenesium.DataConversionExtensions;
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
    <Hash>95c2e55243108844623c8054a32d8e12</Hash>
</Codenesium>*/