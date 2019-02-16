import * as Api from '../../api/models';
import ProductCategoryViewModel from './productCategoryViewModel';

export default class ProductCategoryMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductCategoryClientResponseModel
  ): ProductCategoryViewModel {
    let response = new ProductCategoryViewModel();
    response.setProperties(
      dto.modifiedDate,
      dto.name,
      dto.productCategoryID,
      dto.rowguid
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: ProductCategoryViewModel
  ): Api.ProductCategoryClientRequestModel {
    let response = new Api.ProductCategoryClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.name,
      model.productCategoryID,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>bb84c59420bd10c41c963a243735fc42</Hash>
</Codenesium>*/