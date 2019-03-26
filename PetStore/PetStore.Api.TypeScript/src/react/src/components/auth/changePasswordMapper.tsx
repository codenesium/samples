import * as Api from './models';
import ChangePasswordViewModel from './changePasswordViewModel';
export default class ChangePasswordMapper {
  mapApiResponseToViewModel(
    dto: Api.ChangePasswordClientRequestModel
  ): ChangePasswordViewModel {
    let response = new ChangePasswordViewModel();
    response.setProperties(
      dto.currentPassword,
      dto.newPassword
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ChangePasswordViewModel
  ): Api.ChangePasswordClientRequestModel {
    let response = new Api.ChangePasswordClientRequestModel();
    response.setProperties(
      model.currentPassword,
      model.newPassword
    );
    return response;
  }
}
