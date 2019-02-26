import * as Api from '../../api/models';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import ProductViewModel from '../product/productViewModel';
import UnitMeasureViewModel from '../unitMeasure/unitMeasureViewModel';
export default class BillOfMaterialMapper {
  mapApiResponseToViewModel(
    dto: Api.BillOfMaterialClientResponseModel
  ): BillOfMaterialViewModel {
    let response = new BillOfMaterialViewModel();
    response.setProperties(
      dto.billOfMaterialsID,
      dto.bOMLevel,
      dto.componentID,
      dto.endDate,
      dto.modifiedDate,
      dto.perAssemblyQty,
      dto.productAssemblyID,
      dto.startDate,
      dto.unitMeasureCode
    );

    if (dto.componentIDNavigation != null) {
      response.componentIDNavigation = new ProductViewModel();
      response.componentIDNavigation.setProperties(
        dto.componentIDNavigation.color,
        dto.componentIDNavigation.daysToManufacture,
        dto.componentIDNavigation.discontinuedDate,
        dto.componentIDNavigation.finishedGoodsFlag,
        dto.componentIDNavigation.listPrice,
        dto.componentIDNavigation.makeFlag,
        dto.componentIDNavigation.modifiedDate,
        dto.componentIDNavigation.name,
        dto.componentIDNavigation.productID,
        dto.componentIDNavigation.productLine,
        dto.componentIDNavigation.productModelID,
        dto.componentIDNavigation.productNumber,
        dto.componentIDNavigation.productSubcategoryID,
        dto.componentIDNavigation.reorderPoint,
        dto.componentIDNavigation.rowguid,
        dto.componentIDNavigation.safetyStockLevel,
        dto.componentIDNavigation.sellEndDate,
        dto.componentIDNavigation.sellStartDate,
        dto.componentIDNavigation.size,
        dto.componentIDNavigation.sizeUnitMeasureCode,
        dto.componentIDNavigation.standardCost,
        dto.componentIDNavigation.style,
        dto.componentIDNavigation.weight,
        dto.componentIDNavigation.weightUnitMeasureCode
      );
    }
    if (dto.productAssemblyIDNavigation != null) {
      response.productAssemblyIDNavigation = new ProductViewModel();
      response.productAssemblyIDNavigation.setProperties(
        dto.productAssemblyIDNavigation.color,
        dto.productAssemblyIDNavigation.daysToManufacture,
        dto.productAssemblyIDNavigation.discontinuedDate,
        dto.productAssemblyIDNavigation.finishedGoodsFlag,
        dto.productAssemblyIDNavigation.listPrice,
        dto.productAssemblyIDNavigation.makeFlag,
        dto.productAssemblyIDNavigation.modifiedDate,
        dto.productAssemblyIDNavigation.name,
        dto.productAssemblyIDNavigation.productID,
        dto.productAssemblyIDNavigation.productLine,
        dto.productAssemblyIDNavigation.productModelID,
        dto.productAssemblyIDNavigation.productNumber,
        dto.productAssemblyIDNavigation.productSubcategoryID,
        dto.productAssemblyIDNavigation.reorderPoint,
        dto.productAssemblyIDNavigation.rowguid,
        dto.productAssemblyIDNavigation.safetyStockLevel,
        dto.productAssemblyIDNavigation.sellEndDate,
        dto.productAssemblyIDNavigation.sellStartDate,
        dto.productAssemblyIDNavigation.size,
        dto.productAssemblyIDNavigation.sizeUnitMeasureCode,
        dto.productAssemblyIDNavigation.standardCost,
        dto.productAssemblyIDNavigation.style,
        dto.productAssemblyIDNavigation.weight,
        dto.productAssemblyIDNavigation.weightUnitMeasureCode
      );
    }
    if (dto.unitMeasureCodeNavigation != null) {
      response.unitMeasureCodeNavigation = new UnitMeasureViewModel();
      response.unitMeasureCodeNavigation.setProperties(
        dto.unitMeasureCodeNavigation.modifiedDate,
        dto.unitMeasureCodeNavigation.name,
        dto.unitMeasureCodeNavigation.unitMeasureCode
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: BillOfMaterialViewModel
  ): Api.BillOfMaterialClientRequestModel {
    let response = new Api.BillOfMaterialClientRequestModel();
    response.setProperties(
      model.billOfMaterialsID,
      model.bOMLevel,
      model.componentID,
      model.endDate,
      model.modifiedDate,
      model.perAssemblyQty,
      model.productAssemblyID,
      model.startDate,
      model.unitMeasureCode
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>90afc8f8728cfaffe700b1ec8cc6c4f8</Hash>
</Codenesium>*/