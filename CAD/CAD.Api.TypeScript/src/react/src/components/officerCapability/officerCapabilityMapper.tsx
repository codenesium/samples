import * as Api from '../../api/models';
import OfficerCapabilityViewModel from  './officerCapabilityViewModel';
export default class OfficerCapabilityMapper {
    
	mapApiResponseToViewModel(dto: Api.OfficerCapabilityClientResponseModel) : OfficerCapabilityViewModel 
	{
		let response = new OfficerCapabilityViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: OfficerCapabilityViewModel) : Api.OfficerCapabilityClientRequestModel
	{
		let response = new Api.OfficerCapabilityClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>0379a62da6608883c092f86e7903b68f</Hash>
</Codenesium>*/