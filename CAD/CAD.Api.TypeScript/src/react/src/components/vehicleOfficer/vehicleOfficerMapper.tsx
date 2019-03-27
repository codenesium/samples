import * as Api from '../../api/models';
import VehicleOfficerViewModel from './vehicleOfficerViewModel';
import OfficerViewModel from '../officer/officerViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';
export default class VehicleOfficerMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleOfficerClientResponseModel
  ): VehicleOfficerViewModel {
    let response = new VehicleOfficerViewModel();
    response.setProperties(dto.id, dto.officerId, dto.vehicleId);

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
    if (dto.vehicleIdNavigation != null) {
      response.vehicleIdNavigation = new VehicleViewModel();
      response.vehicleIdNavigation.setProperties(
        dto.vehicleIdNavigation.id,
        dto.vehicleIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: VehicleOfficerViewModel
  ): Api.VehicleOfficerClientRequestModel {
    let response = new Api.VehicleOfficerClientRequestModel();
    response.setProperties(model.id, model.officerId, model.vehicleId);
    return response;
  }
}


/*<Codenesium>
    <Hash>60029f00fd0e3dd1eb6369a9db538fa3</Hash>
</Codenesium>*/