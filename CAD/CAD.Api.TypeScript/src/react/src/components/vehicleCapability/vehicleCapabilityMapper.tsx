import * as Api from '../../api/models';
import VehicleCapabilityViewModel from './vehicleCapabilityViewModel';
export default class VehicleCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleCapabilityClientResponseModel
  ): VehicleCapabilityViewModel {
    let response = new VehicleCapabilityViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: VehicleCapabilityViewModel
  ): Api.VehicleCapabilityClientRequestModel {
    let response = new Api.VehicleCapabilityClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>0b1c88b01f72b359d6714eaa8d032cfb</Hash>
</Codenesium>*/