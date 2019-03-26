import * as Api from '../../api/models';
import ProductProductPhotoViewModel from './productProductPhotoViewModel';
import ProductViewModel from '../product/productViewModel';
import ProductPhotoViewModel from '../productPhoto/productPhotoViewModel';
export default class ProductProductPhotoMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductProductPhotoClientResponseModel
  ): ProductProductPhotoViewModel {
    let response = new ProductProductPhotoViewModel();
    response.setProperties(
      dto.modifiedDate,
      dto.primary,
      dto.productID,
      dto.productPhotoID
    );

    if (dto.productIDNavigation != null) {
      response.productIDNavigation = new ProductViewModel();
      response.productIDNavigation.setProperties(
        dto.productIDNavigation.reservedClass,
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
    if (dto.productPhotoIDNavigation != null) {
      response.productPhotoIDNavigation = new ProductPhotoViewModel();
      response.productPhotoIDNavigation.setProperties(
        dto.productPhotoIDNavigation.largePhoto,
        dto.productPhotoIDNavigation.largePhotoFileName,
        dto.productPhotoIDNavigation.modifiedDate,
        dto.productPhotoIDNavigation.productPhotoID,
        dto.productPhotoIDNavigation.thumbNailPhoto,
        dto.productPhotoIDNavigation.thumbnailPhotoFileName
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductProductPhotoViewModel
  ): Api.ProductProductPhotoClientRequestModel {
    let response = new Api.ProductProductPhotoClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.primary,
      model.productID,
      model.productPhotoID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>d520921258b1dadf378b9a7f718e20f2</Hash>
</Codenesium>*/