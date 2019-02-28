import * as Api from '../../api/models';
import OfficerViewModel from  './officerViewModel';
export default class OfficerMapper {
    
	mapApiResponseToViewModel(dto: Api.OfficerClientResponseModel) : OfficerViewModel 
	{
		let response = new OfficerViewModel();
		response.setProperties(dto.badge,dto.email,dto.firstName,dto.id,dto.lastName,dto.password);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: OfficerViewModel) : Api.OfficerClientRequestModel
	{
		let response = new Api.OfficerClientRequestModel();
		response.setProperties(model.badge,model.email,model.firstName,model.id,model.lastName,model.password);
		return response;
	}
};

/*<Codenesium>
    <Hash>63515d3b8f0b44db7d2b50923ccc1970</Hash>
</Codenesium>*/