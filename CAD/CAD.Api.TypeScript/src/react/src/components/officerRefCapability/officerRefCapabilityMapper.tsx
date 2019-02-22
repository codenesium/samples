import * as Api from '../../api/models';
import OfficerRefCapabilityViewModel from './officerRefCapabilityViewModel';
import OfficerCapabilityViewModel from '../officerCapability/officerCapabilityViewModel';
import OfficerViewModel from '../officer/officerViewModel';
export default class OfficerRefCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.OfficerRefCapabilityClientResponseModel
  ): OfficerRefCapabilityViewModel {
    let response = new OfficerRefCapabilityViewModel();
    response.setProperties(dto.capabilityId, dto.id, dto.officerId);

    if (dto.capabilityIdNavigation != null) {
      response.capabilityIdNavigation = new OfficerCapabilityViewModel();
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
    model: OfficerRefCapabilityViewModel
  ): Api.OfficerRefCapabilityClientRequestModel {
    let response = new Api.OfficerRefCapabilityClientRequestModel();
    response.setProperties(model.capabilityId, model.id, model.officerId);
    return response;
  }
}


/*<Codenesium>
    <Hash>cfd51e4a05afa6f29d0f5316df2e04a6</Hash>
</Codenesium>*/