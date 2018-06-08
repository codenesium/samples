using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractWorkOrderMapper
        {
                public virtual BOWorkOrder MapModelToBO(
                        int workOrderID,
                        ApiWorkOrderRequestModel model
                        )
                {
                        BOWorkOrder boWorkOrder = new BOWorkOrder();

                        boWorkOrder.SetProperties(
                                workOrderID,
                                model.DueDate,
                                model.EndDate,
                                model.ModifiedDate,
                                model.OrderQty,
                                model.ProductID,
                                model.ScrappedQty,
                                model.ScrapReasonID,
                                model.StartDate,
                                model.StockedQty);
                        return boWorkOrder;
                }

                public virtual ApiWorkOrderResponseModel MapBOToModel(
                        BOWorkOrder boWorkOrder)
                {
                        var model = new ApiWorkOrderResponseModel();

                        model.SetProperties(boWorkOrder.DueDate, boWorkOrder.EndDate, boWorkOrder.ModifiedDate, boWorkOrder.OrderQty, boWorkOrder.ProductID, boWorkOrder.ScrappedQty, boWorkOrder.ScrapReasonID, boWorkOrder.StartDate, boWorkOrder.StockedQty, boWorkOrder.WorkOrderID);

                        return model;
                }

                public virtual List<ApiWorkOrderResponseModel> MapBOToModel(
                        List<BOWorkOrder> items)
                {
                        List<ApiWorkOrderResponseModel> response = new List<ApiWorkOrderResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1303bf8f252f3d704279cd95bc363a7b</Hash>
</Codenesium>*/