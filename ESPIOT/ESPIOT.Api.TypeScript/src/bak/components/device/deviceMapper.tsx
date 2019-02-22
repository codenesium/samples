import * as Api from '../../api/models';
import DeviceViewModel from './deviceViewModel';
export default class DeviceMapper {
  mapApiResponseToViewModel(
    dto: Api.DeviceClientResponseModel
  ): DeviceViewModel {
    let response = new DeviceViewModel();
    response.setProperties(dto.id, dto.name, dto.publicId);

    return response;
  }

  mapViewModelToApiRequest(
    model: DeviceViewModel
  ): Api.DeviceClientRequestModel {
    let response = new Api.DeviceClientRequestModel();
    response.setProperties(model.id, model.name, model.publicId);
    return response;
  }
}


/*<Codenesium>
    <Hash>32453890078950bfc51c2fa26e68d4cf</Hash>
</Codenesium>*/