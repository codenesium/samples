import * as Api from '../../api/models';
import VehicleCapabilitiesViewModel from './vehicleCapabilitiesViewModel';
import VehCapabilityViewModel from '../vehCapability/vehCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';
export default class VehicleCapabilitiesMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleCapabilitiesClientResponseModel
  ): VehicleCapabilitiesViewModel {
    let response = new VehicleCapabilitiesViewModel();
    response.setProperties(dto.id, dto.vehicleCapabilityId, dto.vehicleId);

    if (dto.vehicleCapabilityIdNavigation != null) {
      response.vehicleCapabilityIdNavigation = new VehCapabilityViewModel();
      response.vehicleCapabilityIdNavigation.setProperties(
        dto.vehicleCapabilityIdNavigation.id,
        dto.vehicleCapabilityIdNavigation.name
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
    model: VehicleCapabilitiesViewModel
  ): Api.VehicleCapabilitiesClientRequestModel {
    let response = new Api.VehicleCapabilitiesClientRequestModel();
    response.setProperties(
      model.id,
      model.vehicleCapabilityId,
      model.vehicleId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>9abc027f84c96167f891ee11102d654d</Hash>
</Codenesium>*/