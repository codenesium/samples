import * as Api from '../../api/models';
import StudentViewModel from './studentViewModel';
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
      dto.lastName,
      dto.phone,
      dto.smsRemindersEnabled,
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
      model.lastName,
      model.phone,
      model.smsRemindersEnabled,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>4ba452db78619a4daca6cfc64e144853</Hash>
</Codenesium>*/