import * as Api from '../../api/models';
import AddressViewModel from  './addressViewModel';
export default class AddressMapper {
    
	mapApiResponseToViewModel(dto: Api.AddressClientResponseModel) : AddressViewModel 
	{
		let response = new AddressViewModel();
		response.setProperties(dto.address1,dto.address2,dto.city,dto.id,dto.state,dto.zip);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AddressViewModel) : Api.AddressClientRequestModel
	{
		let response = new Api.AddressClientRequestModel();
		response.setProperties(model.address1,model.address2,model.city,model.id,model.state,model.zip);
		return response;
	}
};

/*<Codenesium>
    <Hash>ff6cd23f1e8f8c845d1118063cd40749</Hash>
</Codenesium>*/