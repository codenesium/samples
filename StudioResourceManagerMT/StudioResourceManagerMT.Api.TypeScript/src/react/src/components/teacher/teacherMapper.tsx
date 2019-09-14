import * as Api from '../../api/models';
import TeacherViewModel from './teacherViewModel';
import UserViewModel from '../user/userViewModel';
export default class TeacherMapper {
  mapApiResponseToViewModel(
    dto: Api.TeacherClientResponseModel
  ): TeacherViewModel {
    let response = new TeacherViewModel();
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

  mapViewModelToApiRequest(
    model: TeacherViewModel
  ): Api.TeacherClientRequestModel {
    let response = new Api.TeacherClientRequestModel();
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
    <Hash>7a75fa95cdd6ad020c2bc2e732e45a68</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/