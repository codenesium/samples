import * as Api from '../api/models';
import TeacherViewModel from '../viewmodels/teacherViewModel';

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
      dto.isDeleted,
      dto.lastName,
      dto.phone,
      dto.tenantId,
      dto.userId
    );
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
      model.isDeleted,
      model.lastName,
      model.phone,
      model.tenantId,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b2d85c11da7ceac822f9439342f8ddc4</Hash>
</Codenesium>*/