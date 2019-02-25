import * as Api from '../../api/models';
import ProductDescriptionViewModel from './productDescriptionViewModel';
export default class ProductDescriptionMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductDescriptionClientResponseModel
  ): ProductDescriptionViewModel {
    let response = new ProductDescriptionViewModel();
    response.setProperties(
      dto.description,
      dto.modifiedDate,
      dto.productDescriptionID,
      dto.rowguid
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductDescriptionViewModel
  ): Api.ProductDescriptionClientRequestModel {
    let response = new Api.ProductDescriptionClientRequestModel();
    response.setProperties(
      model.description,
      model.modifiedDate,
      model.productDescriptionID,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>04c35baecf9d7e9e1ca82dc08d21443d</Hash>
</Codenesium>*/