using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractWorkOrderMapper
        {
                public virtual WorkOrder MapBOToEF(
                        BOWorkOrder bo)
                {
                        WorkOrder efWorkOrder = new WorkOrder();

                        efWorkOrder.SetProperties(
                                bo.DueDate,
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.OrderQty,
                                bo.ProductID,
                                bo.ScrappedQty,
                                bo.ScrapReasonID,
                                bo.StartDate,
                                bo.StockedQty,
                                bo.WorkOrderID);
                        return efWorkOrder;
                }

                public virtual BOWorkOrder MapEFToBO(
                        WorkOrder ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOWorkOrder();

                        bo.SetProperties(
                                ef.WorkOrderID,
                                ef.DueDate,
                                ef.EndDate,
                                ef.ModifiedDate,
                                ef.OrderQty,
                                ef.ProductID,
                                ef.ScrappedQty,
                                ef.ScrapReasonID,
                                ef.StartDate,
                                ef.StockedQty);
                        return bo;
                }

                public virtual List<BOWorkOrder> MapEFToBO(
                        List<WorkOrder> records)
                {
                        List<BOWorkOrder> response = new List<BOWorkOrder>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d037a93f83682aa53839853a984f8173</Hash>
</Codenesium>*/