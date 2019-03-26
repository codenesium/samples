import * as Api from './models';
import ResetPasswordViewModel from './resetPasswordViewModel';
export default class ResetPasswordMapper {
  mapApiResponseToViewModel(
    dto: Api.ResetPasswordClientRequestModel
  ): ResetPasswordViewModel {
    let response = new ResetPasswordViewModel();
    response.setProperties(
      dto.email
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ResetPasswordViewModel
  ): Api.ResetPasswordClientRequestModel {
    let response = new Api.ResetPasswordClientRequestModel();
    response.setProperties(
      model.email
    );
    return response;
  }
}
