import * as Api from '../../api/models';
import VehCapabilityViewModel from './vehCapabilityViewModel';
export default class VehCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.VehCapabilityClientResponseModel
  ): VehCapabilityViewModel {
    let response = new VehCapabilityViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: VehCapabilityViewModel
  ): Api.VehCapabilityClientRequestModel {
    let response = new Api.VehCapabilityClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>7c64d767a7646a171cbaa76c37a2b387</Hash>
</Codenesium>*/