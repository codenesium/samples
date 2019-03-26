import * as Api from './models';
import LoginViewModel from './loginViewModel';
export default class LoginMapper {
  mapApiResponseToViewModel(
    dto: Api.LoginClientRequestModel
  ): LoginViewModel {
    let response = new LoginViewModel();
    response.setProperties(
      dto.email,
      dto.password
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: LoginViewModel
  ): Api.LoginClientRequestModel {
    let response = new Api.LoginClientRequestModel();
    response.setProperties(
      model.email,
      model.password
    );
    return response;
  }
}
