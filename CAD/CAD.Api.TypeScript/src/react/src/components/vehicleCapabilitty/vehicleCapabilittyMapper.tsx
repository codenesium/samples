import * as Api from '../../api/models';
import VehicleCapabilittyViewModel from './vehicleCapabilittyViewModel';
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';
export default class VehicleCapabilittyMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleCapabilittyClientResponseModel
  ): VehicleCapabilittyViewModel {
    let response = new VehicleCapabilittyViewModel();
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
    model: VehicleCapabilittyViewModel
  ): Api.VehicleCapabilittyClientRequestModel {
    let response = new Api.VehicleCapabilittyClientRequestModel();
    response.setProperties(model.vehicleCapabilityId, model.vehicleId);
    return response;
  }
}


/*<Codenesium>
    <Hash>08a0ef28ab5342cea01a276301ba5784</Hash>
</Codenesium>*/