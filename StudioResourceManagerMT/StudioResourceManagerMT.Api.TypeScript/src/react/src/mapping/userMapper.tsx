import * as Api from '../api/models';
import UserViewModel from  '../viewmodels/userViewModel';

export default class UserMapper {
    
	mapApiResponseToViewModel(dto: Api.UserClientResponseModel) : UserViewModel 
	{
		let response = new UserViewModel();
		response.setProperties(dto.id,dto.isDeleted,dto.password,dto.tenantId,dto.username);
		return response;
	}

	mapViewModelToApiRequest(model: UserViewModel) : Api.UserClientRequestModel
	{
		let response = new Api.UserClientRequestModel();
		response.setProperties(model.id,model.isDeleted,model.password,model.tenantId,model.username);
		return response;
	}
};

/*<Codenesium>
    <Hash>baee872dd5233f7ba2e4c5777e8a409c</Hash>
</Codenesium>*/