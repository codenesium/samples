import * as Api from '../../api/models';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';
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
    <Hash>9a3e5d423a4aaa72c21ee6f1889bb042</Hash>
</Codenesium>*/