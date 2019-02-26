import * as Api from '../../api/models';
import VehicleRefCapabilityViewModel from './vehicleRefCapabilityViewModel';
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';
export default class VehicleRefCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleRefCapabilityClientResponseModel
  ): VehicleRefCapabilityViewModel {
    let response = new VehicleRefCapabilityViewModel();
    response.setProperties(dto.id, dto.vehicleCapabilityId, dto.vehicleId);

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
    model: VehicleRefCapabilityViewModel
  ): Api.VehicleRefCapabilityClientRequestModel {
    let response = new Api.VehicleRefCapabilityClientRequestModel();
    response.setProperties(
      model.id,
      model.vehicleCapabilityId,
      model.vehicleId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>495ce8222e0b8b63dcf5b9d81445664d</Hash>
</Codenesium>*/