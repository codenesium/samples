import * as Api from '../../api/models';
import ProductViewModel from './productViewModel';
export default class ProductMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductClientResponseModel
  ): ProductViewModel {
    let response = new ProductViewModel();
    response.setProperties(
      dto.active,
      dto.description,
      dto.id,
      dto.name,
      dto.price,
      dto.quantity
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductViewModel
  ): Api.ProductClientRequestModel {
    let response = new Api.ProductClientRequestModel();
    response.setProperties(
      model.active,
      model.description,
      model.id,
      model.name,
      model.price,
      model.quantity
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2d5f215638e78235f73137d6492bdc5f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/