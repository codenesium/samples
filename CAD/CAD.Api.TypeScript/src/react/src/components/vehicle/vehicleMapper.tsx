import * as Api from '../../api/models';
import VehicleViewModel from './vehicleViewModel';
export default class VehicleMapper {
  mapApiResponseToViewModel(
    dto: Api.VehicleClientResponseModel
  ): VehicleViewModel {
    let response = new VehicleViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: VehicleViewModel
  ): Api.VehicleClientRequestModel {
    let response = new Api.VehicleClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>d22ab270c289d42c801d47bf14793f03</Hash>
</Codenesium>*/