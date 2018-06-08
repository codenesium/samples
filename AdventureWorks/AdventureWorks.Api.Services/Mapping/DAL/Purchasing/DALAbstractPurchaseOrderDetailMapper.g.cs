using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractPurchaseOrderDetailMapper
        {
                public virtual PurchaseOrderDetail MapBOToEF(
                        BOPurchaseOrderDetail bo)
                {
                        PurchaseOrderDetail efPurchaseOrderDetail = new PurchaseOrderDetail();

                        efPurchaseOrderDetail.SetProperties(
                                bo.DueDate,
                                bo.LineTotal,
                                bo.ModifiedDate,
                                bo.OrderQty,
                                bo.ProductID,
                                bo.PurchaseOrderDetailID,
                                bo.PurchaseOrderID,
                                bo.ReceivedQty,
                                bo.RejectedQty,
                                bo.StockedQty,
                                bo.UnitPrice);
                        return efPurchaseOrderDetail;
                }

                public virtual BOPurchaseOrderDetail MapEFToBO(
                        PurchaseOrderDetail ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOPurchaseOrderDetail();

                        bo.SetProperties(
                                ef.PurchaseOrderID,
                                ef.DueDate,
                                ef.LineTotal,
                                ef.ModifiedDate,
                                ef.OrderQty,
                                ef.ProductID,
                                ef.PurchaseOrderDetailID,
                                ef.ReceivedQty,
                                ef.RejectedQty,
                                ef.StockedQty,
                                ef.UnitPrice);
                        return bo;
                }

                public virtual List<BOPurchaseOrderDetail> MapEFToBO(
                        List<PurchaseOrderDetail> records)
                {
                        List<BOPurchaseOrderDetail> response = new List<BOPurchaseOrderDetail>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>20ff08d0355214a0b1d97e4c47c7c71f</Hash>
</Codenesium>*/