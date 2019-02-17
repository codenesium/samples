import * as Api from '../../api/models';
import ProductModelViewModel from  './productModelViewModel';
export default class ProductModelMapper {
    
	mapApiResponseToViewModel(dto: Api.ProductModelClientResponseModel) : ProductModelViewModel 
	{
		let response = new ProductModelViewModel();
		response.setProperties(dto.catalogDescription,dto.instruction,dto.modifiedDate,dto.name,dto.productModelID,dto.rowguid);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ProductModelViewModel) : Api.ProductModelClientRequestModel
	{
		let response = new Api.ProductModelClientRequestModel();
		response.setProperties(model.catalogDescription,model.instruction,model.modifiedDate,model.name,model.productModelID,model.rowguid);
		return response;
	}
};

/*<Codenesium>
    <Hash>2a8e537c0da93b9156e7c03ecbf9e2cc</Hash>
</Codenesium>*/