import * as Api from '../../api/models';
import OfficerCapabilitiesViewModel from './officerCapabilitiesViewModel';
import OffCapabilityViewModel from '../offCapability/offCapabilityViewModel';
import OfficerViewModel from '../officer/officerViewModel';
export default class OfficerCapabilitiesMapper {
  mapApiResponseToViewModel(
    dto: Api.OfficerCapabilitiesClientResponseModel
  ): OfficerCapabilitiesViewModel {
    let response = new OfficerCapabilitiesViewModel();
    response.setProperties(dto.capabilityId, dto.id, dto.officerId);

    if (dto.capabilityIdNavigation != null) {
      response.capabilityIdNavigation = new OffCapabilityViewModel();
      response.capabilityIdNavigation.setProperties(
        dto.capabilityIdNavigation.id,
        dto.capabilityIdNavigation.name
      );
    }
    if (dto.officerIdNavigation != null) {
      response.officerIdNavigation = new OfficerViewModel();
      response.officerIdNavigation.setProperties(
        dto.officerIdNavigation.badge,
        dto.officerIdNavigation.email,
        dto.officerIdNavigation.firstName,
        dto.officerIdNavigation.id,
        dto.officerIdNavigation.lastName,
        dto.officerIdNavigation.password
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: OfficerCapabilitiesViewModel
  ): Api.OfficerCapabilitiesClientRequestModel {
    let response = new Api.OfficerCapabilitiesClientRequestModel();
    response.setProperties(model.capabilityId, model.id, model.officerId);
    return response;
  }
}


/*<Codenesium>
    <Hash>41b1adf9f6cee42c21b09f4022d6ad74</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/