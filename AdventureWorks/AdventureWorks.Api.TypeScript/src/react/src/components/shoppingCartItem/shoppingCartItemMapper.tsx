import * as Api from '../../api/models';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';
export default class ShoppingCartItemMapper {
  mapApiResponseToViewModel(
    dto: Api.ShoppingCartItemClientResponseModel
  ): ShoppingCartItemViewModel {
    let response = new ShoppingCartItemViewModel();
    response.setProperties(
      dto.dateCreated,
      dto.modifiedDate,
      dto.productID,
      dto.quantity,
      dto.shoppingCartID,
      dto.shoppingCartItemID
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ShoppingCartItemViewModel
  ): Api.ShoppingCartItemClientRequestModel {
    let response = new Api.ShoppingCartItemClientRequestModel();
    response.setProperties(
      model.dateCreated,
      model.modifiedDate,
      model.productID,
      model.quantity,
      model.shoppingCartID,
      model.shoppingCartItemID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>6ff4ebae878d9fe3aa80939e4ae61331</Hash>
</Codenesium>*/