import * as Api from '../../api/models';
import AdminViewModel from  './adminViewModel';
export default class AdminMapper {
    
	mapApiResponseToViewModel(dto: Api.AdminClientResponseModel) : AdminViewModel 
	{
		let response = new AdminViewModel();
		response.setProperties(dto.birthday,dto.email,dto.firstName,dto.id,dto.lastName,dto.phone,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AdminViewModel) : Api.AdminClientRequestModel
	{
		let response = new Api.AdminClientRequestModel();
		response.setProperties(model.birthday,model.email,model.firstName,model.id,model.lastName,model.phone,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>ff00e3899f27a614e1872c98fda24fb9</Hash>
</Codenesium>*/