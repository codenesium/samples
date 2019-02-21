import * as Api from '../../api/models';
import ProductViewModel from './productViewModel';
export default class ProductMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductClientResponseModel
  ): ProductViewModel {
    let response = new ProductViewModel();
    response.setProperties(
      dto.color,
      dto.daysToManufacture,
      dto.discontinuedDate,
      dto.finishedGoodsFlag,
      dto.listPrice,
      dto.makeFlag,
      dto.modifiedDate,
      dto.name,
      dto.productID,
      dto.productLine,
      dto.productModelID,
      dto.productNumber,
      dto.productSubcategoryID,
      dto.reorderPoint,
      dto.rowguid,
      dto.safetyStockLevel,
      dto.sellEndDate,
      dto.sellStartDate,
      dto.size,
      dto.sizeUnitMeasureCode,
      dto.standardCost,
      dto.style,
      dto.weight,
      dto.weightUnitMeasureCode
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductViewModel
  ): Api.ProductClientRequestModel {
    let response = new Api.ProductClientRequestModel();
    response.setProperties(
      model.color,
      model.daysToManufacture,
      model.discontinuedDate,
      model.finishedGoodsFlag,
      model.listPrice,
      model.makeFlag,
      model.modifiedDate,
      model.name,
      model.productID,
      model.productLine,
      model.productModelID,
      model.productNumber,
      model.productSubcategoryID,
      model.reorderPoint,
      model.rowguid,
      model.safetyStockLevel,
      model.sellEndDate,
      model.sellStartDate,
      model.size,
      model.sizeUnitMeasureCode,
      model.standardCost,
      model.style,
      model.weight,
      model.weightUnitMeasureCode
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>adcadce8fb7e6f550629b04133c67c33</Hash>
</Codenesium>*/