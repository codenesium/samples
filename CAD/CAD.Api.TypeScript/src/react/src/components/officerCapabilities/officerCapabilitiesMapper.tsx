import * as Api from '../../api/models';
import OfficerCapabilitiesViewModel from  './officerCapabilitiesViewModel';
	import OfficerCapabilityViewModel from '../officerCapability/officerCapabilityViewModel'
		import OfficerViewModel from '../officer/officerViewModel'
	export default class OfficerCapabilitiesMapper {
    
	mapApiResponseToViewModel(dto: Api.OfficerCapabilitiesClientResponseModel) : OfficerCapabilitiesViewModel 
	{
		let response = new OfficerCapabilitiesViewModel();
		response.setProperties(dto.capabilityId,dto.officerId);
		
						if(dto.capabilityIdNavigation != null)
				{
				  response.capabilityIdNavigation = new OfficerCapabilityViewModel();
				  response.capabilityIdNavigation.setProperties(
				  dto.capabilityIdNavigation.id,dto.capabilityIdNavigation.name
				  );
				}
							if(dto.officerIdNavigation != null)
				{
				  response.officerIdNavigation = new OfficerViewModel();
				  response.officerIdNavigation.setProperties(
				  dto.officerIdNavigation.badge,dto.officerIdNavigation.email,dto.officerIdNavigation.firstName,dto.officerIdNavigation.id,dto.officerIdNavigation.lastName,dto.officerIdNavigation.password
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: OfficerCapabilitiesViewModel) : Api.OfficerCapabilitiesClientRequestModel
	{
		let response = new Api.OfficerCapabilitiesClientRequestModel();
		response.setProperties(model.capabilityId,model.officerId);
		return response;
	}
};

/*<Codenesium>
    <Hash>d767e7b97371fd62f141d705279da837</Hash>
</Codenesium>*/