import * as Api from '../../api/models';
import ShoppingCartItemViewModel from  './shoppingCartItemViewModel';
export default class ShoppingCartItemMapper {
    
	mapApiResponseToViewModel(dto: Api.ShoppingCartItemClientResponseModel) : ShoppingCartItemViewModel 
	{
		let response = new ShoppingCartItemViewModel();
		response.setProperties(dto.dateCreated,dto.modifiedDate,dto.productID,dto.quantity,dto.shoppingCartID,dto.shoppingCartItemID);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ShoppingCartItemViewModel) : Api.ShoppingCartItemClientRequestModel
	{
		let response = new Api.ShoppingCartItemClientRequestModel();
		response.setProperties(model.dateCreated,model.modifiedDate,model.productID,model.quantity,model.shoppingCartID,model.shoppingCartItemID);
		return response;
	}
};

/*<Codenesium>
    <Hash>d3f76931b45b0496928333a70ce8e5af</Hash>
</Codenesium>*/