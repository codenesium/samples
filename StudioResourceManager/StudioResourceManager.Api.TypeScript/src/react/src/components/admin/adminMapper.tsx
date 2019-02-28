import * as Api from '../../api/models';
import AdminViewModel from './adminViewModel';
import UserViewModel from '../user/userViewModel';
export default class AdminMapper {
  mapApiResponseToViewModel(dto: Api.AdminClientResponseModel): AdminViewModel {
    let response = new AdminViewModel();
    response.setProperties(
      dto.birthday,
      dto.email,
      dto.firstName,
      dto.id,
      dto.lastName,
      dto.phone,
      dto.userId
    );

    if (dto.userIdNavigation != null) {
      response.userIdNavigation = new UserViewModel();
      response.userIdNavigation.setProperties(
        dto.userIdNavigation.id,
        dto.userIdNavigation.password,
        dto.userIdNavigation.username
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: AdminViewModel): Api.AdminClientRequestModel {
    let response = new Api.AdminClientRequestModel();
    response.setProperties(
      model.birthday,
      model.email,
      model.firstName,
      model.id,
      model.lastName,
      model.phone,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>ff9069af82d706941dfd6ee76073b092</Hash>
</Codenesium>*/