import * as Api from '../../api/models';
import VehicleCapabilitiesViewModel from './vehicleCapabilitiesViewModel';
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';
export default class VehicleCapabilitiesMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleCapabilitiesClientResponseModel
  ): VehicleCapabilitiesViewModel {
    let response = new VehicleCapabilitiesViewModel();
    response.setProperties(dto.vehicleCapabilityId, dto.vehicleId);

    if (dto.vehicleCapabilityIdNavigation != null) {
      response.vehicleCapabilityIdNavigation = new VehicleCapabilityViewModel();
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
    response.setProperties(model.vehicleCapabilityId, model.vehicleId);
    return response;
  }
}


/*<Codenesium>
    <Hash>b550bb7984aab15c5634da6f6cfcc9b8</Hash>
</Codenesium>*/