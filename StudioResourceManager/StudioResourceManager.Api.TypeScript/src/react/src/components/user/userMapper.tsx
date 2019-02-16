import * as Api from '../../api/models';
import UserViewModel from './userViewModel';
export default class UserMapper {
  mapApiResponseToViewModel(dto: Api.UserClientResponseModel): UserViewModel {
    let response = new UserViewModel();
    response.setProperties(dto.id, dto.password, dto.username);

    return response;
  }

  mapViewModelToApiRequest(model: UserViewModel): Api.UserClientRequestModel {
    let response = new Api.UserClientRequestModel();
    response.setProperties(model.id, model.password, model.username);
    return response;
  }
}


/*<Codenesium>
    <Hash>13d44853f3e5b727085a4d299fce4184</Hash>
</Codenesium>*/