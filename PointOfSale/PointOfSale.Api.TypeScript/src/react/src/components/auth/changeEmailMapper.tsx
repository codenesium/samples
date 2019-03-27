import * as Api from './models';
import ChangeEmailViewModel from './changeEmailViewModel';
export default class ChangeEmailMapper {
  mapApiResponseToViewModel(
    dto: Api.ChangeEmailClientRequestModel
  ): ChangeEmailViewModel {
    let response = new ChangeEmailViewModel();
    response.setProperties(
    dto.password,
    dto.newEmail

    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ChangeEmailViewModel
  ): Api.ChangeEmailClientRequestModel {
    let response = new Api.ChangeEmailClientRequestModel();
    response.setProperties(
      model.password,
      model.newEmail
    );
    return response;
  }
}
