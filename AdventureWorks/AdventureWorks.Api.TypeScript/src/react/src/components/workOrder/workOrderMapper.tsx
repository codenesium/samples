import * as Api from '../../api/models';
import WorkOrderViewModel from './workOrderViewModel';
import ProductViewModel from '../product/productViewModel';
import ScrapReasonViewModel from '../scrapReason/scrapReasonViewModel';
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

    if (dto.productIDNavigation != null) {
      response.productIDNavigation = new ProductViewModel();
      response.productIDNavigation.setProperties(
        dto.productIDNavigation.color,
        dto.productIDNavigation.daysToManufacture,
        dto.productIDNavigation.discontinuedDate,
        dto.productIDNavigation.finishedGoodsFlag,
        dto.productIDNavigation.listPrice,
        dto.productIDNavigation.makeFlag,
        dto.productIDNavigation.modifiedDate,
        dto.productIDNavigation.name,
        dto.productIDNavigation.productID,
        dto.productIDNavigation.productLine,
        dto.productIDNavigation.productModelID,
        dto.productIDNavigation.productNumber,
        dto.productIDNavigation.productSubcategoryID,
        dto.productIDNavigation.reorderPoint,
        dto.productIDNavigation.rowguid,
        dto.productIDNavigation.safetyStockLevel,
        dto.productIDNavigation.sellEndDate,
        dto.productIDNavigation.sellStartDate,
        dto.productIDNavigation.size,
        dto.productIDNavigation.sizeUnitMeasureCode,
        dto.productIDNavigation.standardCost,
        dto.productIDNavigation.style,
        dto.productIDNavigation.weight,
        dto.productIDNavigation.weightUnitMeasureCode
      );
    }
    if (dto.scrapReasonIDNavigation != null) {
      response.scrapReasonIDNavigation = new ScrapReasonViewModel();
      response.scrapReasonIDNavigation.setProperties(
        dto.scrapReasonIDNavigation.modifiedDate,
        dto.scrapReasonIDNavigation.name,
        dto.scrapReasonIDNavigation.scrapReasonID
      );
    }

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
    <Hash>c29276065be204385d7867a878e7f6e6</Hash>
</Codenesium>*/