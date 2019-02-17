import * as Api from '../../api/models';
import AdminViewModel from  './adminViewModel';
export default class AdminMapper {
    
	mapApiResponseToViewModel(dto: Api.AdminClientResponseModel) : AdminViewModel 
	{
		let response = new AdminViewModel();
		response.setProperties(dto.email,dto.firstName,dto.id,dto.lastName,dto.password,dto.phone,dto.username);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AdminViewModel) : Api.AdminClientRequestModel
	{
		let response = new Api.AdminClientRequestModel();
		response.setProperties(model.email,model.firstName,model.id,model.lastName,model.password,model.phone,model.username);
		return response;
	}
};

/*<Codenesium>
    <Hash>777045b218281c676168364dd1e6c8e9</Hash>
</Codenesium>*/