import * as Api from '../../api/models';
import CustomerViewModel from  './customerViewModel';
export default class CustomerMapper {
    
	mapApiResponseToViewModel(dto: Api.CustomerClientResponseModel) : CustomerViewModel 
	{
		let response = new CustomerViewModel();
		response.setProperties(dto.email,dto.firstName,dto.id,dto.lastName,dto.note,dto.phone);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CustomerViewModel) : Api.CustomerClientRequestModel
	{
		let response = new Api.CustomerClientRequestModel();
		response.setProperties(model.email,model.firstName,model.id,model.lastName,model.note,model.phone);
		return response;
	}
};

/*<Codenesium>
    <Hash>3635440f79daf1b37935dfa59a15bf5c</Hash>
</Codenesium>*/