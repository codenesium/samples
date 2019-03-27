import * as Api from './models';
import RegisterViewModel from './registerViewModel';
export default class RegisterMapper {
  mapApiResponseToViewModel(
    dto: Api.RegisterClientRequestModel
  ): RegisterViewModel {
    let response = new RegisterViewModel();
    response.setProperties(
      dto.email,
      dto.password
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: RegisterViewModel
  ): Api.RegisterClientRequestModel {
    let response = new Api.RegisterClientRequestModel();
    response.setProperties(
      model.email,
      model.password
    );
    return response;
  }
}
