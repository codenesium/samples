import * as Api from '../../api/models';
import WorkOrderViewModel from './workOrderViewModel';
export default class WorkOrderMapper {
  mapApiResponseToViewModel(
    dto: Api.WorkOrderClientResponseModel
  ): WorkOrderViewModel {
    let response = new WorkOrderViewModel();
    response.setProperties(
      dto.dueDate,
      dto.endDate,
      dto.modifiedDate,
      dto.orderQty,
      dto.productID,
      dto.scrappedQty,
      dto.scrapReasonID,
      dto.startDate,
      dto.stockedQty,
      dto.workOrderID
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: WorkOrderViewModel
  ): Api.WorkOrderClientRequestModel {
    let response = new Api.WorkOrderClientRequestModel();
    response.setProperties(
      model.dueDate,
      model.endDate,
      model.modifiedDate,
      model.orderQty,
      model.productID,
      model.scrappedQty,
      model.scrapReasonID,
      model.startDate,
      model.stockedQty,
      model.workOrderID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>ab5ac3849ebe573c850c8e5ee5111874</Hash>
</Codenesium>*/