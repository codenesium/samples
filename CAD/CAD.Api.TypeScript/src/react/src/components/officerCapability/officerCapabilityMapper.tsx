import * as Api from '../../api/models';
import OfficerCapabilityViewModel from './officerCapabilityViewModel';
import OfficerViewModel from '../officer/officerViewModel';
export default class OfficerCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.OfficerCapabilityClientResponseModel
  ): OfficerCapabilityViewModel {
    let response = new OfficerCapabilityViewModel();
    response.setProperties(dto.capabilityId, dto.officerId);

    if (dto.capabilityIdNavigation != null) {
      response.capabilityIdNavigation = new OfficerCapabilityViewModel();
      response.capabilityIdNavigation.setProperties(
        dto.capabilityIdNavigation.capabilityId,
        dto.capabilityIdNavigation.officerId
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
    model: OfficerCapabilityViewModel
  ): Api.OfficerCapabilityClientRequestModel {
    let response = new Api.OfficerCapabilityClientRequestModel();
    response.setProperties(model.capabilityId, model.officerId);
    return response;
  }
}


/*<Codenesium>
    <Hash>c0344ca7f36878e0571799271778c8ec</Hash>
</Codenesium>*/