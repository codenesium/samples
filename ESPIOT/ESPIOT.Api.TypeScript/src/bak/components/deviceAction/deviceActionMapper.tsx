import * as Api from '../../api/models';
import DeviceActionViewModel from './deviceActionViewModel';
import DeviceViewModel from '../device/deviceViewModel';
export default class DeviceActionMapper {
  mapApiResponseToViewModel(
    dto: Api.DeviceActionClientResponseModel
  ): DeviceActionViewModel {
    let response = new DeviceActionViewModel();
    response.setProperties(dto.deviceId, dto.id, dto.name, dto.rwValue);

    if (dto.deviceIdNavigation != null) {
      response.deviceIdNavigation = new DeviceViewModel();
      response.deviceIdNavigation.setProperties(
        dto.deviceIdNavigation.id,
        dto.deviceIdNavigation.name,
        dto.deviceIdNavigation.publicId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: DeviceActionViewModel
  ): Api.DeviceActionClientRequestModel {
    let response = new Api.DeviceActionClientRequestModel();
    response.setProperties(model.deviceId, model.id, model.name, model.rwValue);
    return response;
  }
}


/*<Codenesium>
    <Hash>236c3b90c0bff54157d1a23a3764a8a7</Hash>
</Codenesium>*/