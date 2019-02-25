import * as Api from '../../api/models';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';
import ProductCategoryViewModel from '../productCategory/productCategoryViewModel';
export default class ProductSubcategoryMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductSubcategoryClientResponseModel
  ): ProductSubcategoryViewModel {
    let response = new ProductSubcategoryViewModel();
    response.setProperties(
      dto.modifiedDate,
      dto.name,
      dto.productCategoryID,
      dto.productSubcategoryID,
      dto.rowguid
    );

    if (dto.productCategoryIDNavigation != null) {
      response.productCategoryIDNavigation = new ProductCategoryViewModel();
      response.productCategoryIDNavigation.setProperties(
        dto.productCategoryIDNavigation.modifiedDate,
        dto.productCategoryIDNavigation.name,
        dto.productCategoryIDNavigation.productCategoryID,
        dto.productCategoryIDNavigation.rowguid
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductSubcategoryViewModel
  ): Api.ProductSubcategoryClientRequestModel {
    let response = new Api.ProductSubcategoryClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.name,
      model.productCategoryID,
      model.productSubcategoryID,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>5a821d78a0dcf97e31c2dfa478bf7a3f</Hash>
</Codenesium>*/