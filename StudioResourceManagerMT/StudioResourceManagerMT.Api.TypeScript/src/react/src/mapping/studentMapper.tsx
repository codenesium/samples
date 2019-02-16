import * as Api from '../api/models';
import StudentViewModel from '../viewmodels/studentViewModel';

export default class StudentMapper {
  mapApiResponseToViewModel(
    dto: Api.StudentClientResponseModel
  ): StudentViewModel {
    let response = new StudentViewModel();
    response.setProperties(
      dto.birthday,
      dto.email,
      dto.emailRemindersEnabled,
      dto.familyId,
      dto.firstName,
      dto.id,
      dto.isAdult,
      dto.isDeleted,
      dto.lastName,
      dto.phone,
      dto.smsRemindersEnabled,
      dto.tenantId,
      dto.userId
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: StudentViewModel
  ): Api.StudentClientRequestModel {
    let response = new Api.StudentClientRequestModel();
    response.setProperties(
      model.birthday,
      model.email,
      model.emailRemindersEnabled,
      model.familyId,
      model.firstName,
      model.id,
      model.isAdult,
      model.isDeleted,
      model.lastName,
      model.phone,
      model.smsRemindersEnabled,
      model.tenantId,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>0cefb7a9ddc916da373d78e94a2d81e9</Hash>
</Codenesium>*/