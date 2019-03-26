import * as Api from '../../api/models';
import ProductViewModel from './productViewModel';
import ProductModelViewModel from '../productModel/productModelViewModel';
import ProductSubcategoryViewModel from '../productSubcategory/productSubcategoryViewModel';
import UnitMeasureViewModel from '../unitMeasure/unitMeasureViewModel';
export default class ProductMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductClientResponseModel
  ): ProductViewModel {
    let response = new ProductViewModel();
    response.setProperties(
      dto.reservedClass,
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

    if (dto.productModelIDNavigation != null) {
      response.productModelIDNavigation = new ProductModelViewModel();
      response.productModelIDNavigation.setProperties(
        dto.productModelIDNavigation.catalogDescription,
        dto.productModelIDNavigation.instruction,
        dto.productModelIDNavigation.modifiedDate,
        dto.productModelIDNavigation.name,
        dto.productModelIDNavigation.productModelID,
        dto.productModelIDNavigation.rowguid
      );
    }
    if (dto.productSubcategoryIDNavigation != null) {
      response.productSubcategoryIDNavigation = new ProductSubcategoryViewModel();
      response.productSubcategoryIDNavigation.setProperties(
        dto.productSubcategoryIDNavigation.modifiedDate,
        dto.productSubcategoryIDNavigation.name,
        dto.productSubcategoryIDNavigation.productCategoryID,
        dto.productSubcategoryIDNavigation.productSubcategoryID,
        dto.productSubcategoryIDNavigation.rowguid
      );
    }
    if (dto.sizeUnitMeasureCodeNavigation != null) {
      response.sizeUnitMeasureCodeNavigation = new UnitMeasureViewModel();
      response.sizeUnitMeasureCodeNavigation.setProperties(
        dto.sizeUnitMeasureCodeNavigation.modifiedDate,
        dto.sizeUnitMeasureCodeNavigation.name,
        dto.sizeUnitMeasureCodeNavigation.unitMeasureCode
      );
    }
    if (dto.weightUnitMeasureCodeNavigation != null) {
      response.weightUnitMeasureCodeNavigation = new UnitMeasureViewModel();
      response.weightUnitMeasureCodeNavigation.setProperties(
        dto.weightUnitMeasureCodeNavigation.modifiedDate,
        dto.weightUnitMeasureCodeNavigation.name,
        dto.weightUnitMeasureCodeNavigation.unitMeasureCode
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductViewModel
  ): Api.ProductClientRequestModel {
    let response = new Api.ProductClientRequestModel();
    response.setProperties(
      model.reservedClass,
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
    <Hash>e23109b62a2ce4ce50b5ffee16252965</Hash>
</Codenesium>*/