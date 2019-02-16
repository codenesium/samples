import * as Api from '../../api/models';
import DeviceActionViewModel from './deviceActionViewModel';
import DeviceViewModel from '../device/deviceViewModel';
export default class DeviceActionMapper {
  mapApiResponseToViewModel(
    dto: Api.DeviceActionClientResponseModel
  ): DeviceActionViewModel {
    let response = new DeviceActionViewModel();
    response.setProperties(dto.action, dto.deviceId, dto.id, dto.name);

    if (dto.deviceIdNavigation != null) {
      response.deviceIdNavigation = new DeviceViewModel();
      response.deviceIdNavigation.setProperties(
        dto.deviceIdNavigation.dateOfLastPing,
        dto.deviceIdNavigation.id,
        dto.deviceIdNavigation.isActive,
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
    response.setProperties(model.action, model.deviceId, model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>ef85d9f226fdbbb3800ec849fddfbe56</Hash>
</Codenesium>*/