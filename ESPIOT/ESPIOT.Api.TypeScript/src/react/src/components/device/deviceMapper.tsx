import * as Api from '../../api/models';
import DeviceViewModel from './deviceViewModel';
export default class DeviceMapper {
  mapApiResponseToViewModel(
    dto: Api.DeviceClientResponseModel
  ): DeviceViewModel {
    let response = new DeviceViewModel();
    response.setProperties(
      dto.dateOfLastPing,
      dto.id,
      dto.isActive,
      dto.name,
      dto.publicId
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: DeviceViewModel
  ): Api.DeviceClientRequestModel {
    let response = new Api.DeviceClientRequestModel();
    response.setProperties(
      model.dateOfLastPing,
      model.id,
      model.isActive,
      model.name,
      model.publicId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b5f1682d2affcb125e56c5c34220d67f</Hash>
</Codenesium>*/