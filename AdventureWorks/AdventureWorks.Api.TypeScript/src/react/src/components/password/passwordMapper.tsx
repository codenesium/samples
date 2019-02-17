import * as Api from '../../api/models';
import PasswordViewModel from  './passwordViewModel';
export default class PasswordMapper {
    
	mapApiResponseToViewModel(dto: Api.PasswordClientResponseModel) : PasswordViewModel 
	{
		let response = new PasswordViewModel();
		response.setProperties(dto.businessEntityID,dto.modifiedDate,dto.passwordHash,dto.passwordSalt,dto.rowguid);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PasswordViewModel) : Api.PasswordClientRequestModel
	{
		let response = new Api.PasswordClientRequestModel();
		response.setProperties(model.businessEntityID,model.modifiedDate,model.passwordHash,model.passwordSalt,model.rowguid);
		return response;
	}
};

/*<Codenesium>
    <Hash>9a8d97354df65a70b18da1b64851adef</Hash>
</Codenesium>*/