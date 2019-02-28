import * as Api from '../../api/models';
import TransactionHistoryViewModel from './transactionHistoryViewModel';
import ProductViewModel from '../product/productViewModel';
export default class TransactionHistoryMapper {
  mapApiResponseToViewModel(
    dto: Api.TransactionHistoryClientResponseModel
  ): TransactionHistoryViewModel {
    let response = new TransactionHistoryViewModel();
    response.setProperties(
      dto.actualCost,
      dto.modifiedDate,
      dto.productID,
      dto.quantity,
      dto.referenceOrderID,
      dto.referenceOrderLineID,
      dto.transactionDate,
      dto.transactionID,
      dto.transactionType
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

    return response;
  }

  mapViewModelToApiRequest(
    model: TransactionHistoryViewModel
  ): Api.TransactionHistoryClientRequestModel {
    let response = new Api.TransactionHistoryClientRequestModel();
    response.setProperties(
      model.actualCost,
      model.modifiedDate,
      model.productID,
      model.quantity,
      model.referenceOrderID,
      model.referenceOrderLineID,
      model.transactionDate,
      model.transactionID,
      model.transactionType
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>e66eb0c4566961c88fc0fa383a4a07c8</Hash>
</Codenesium>*/