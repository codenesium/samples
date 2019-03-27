import * as Api from '../../api/models';
import StudentViewModel from './studentViewModel';
import FamilyViewModel from '../family/familyViewModel';
import UserViewModel from '../user/userViewModel';
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

    if (dto.familyIdNavigation != null) {
      response.familyIdNavigation = new FamilyViewModel();
      response.familyIdNavigation.setProperties(
        dto.familyIdNavigation.id,
        dto.familyIdNavigation.notes,
        dto.familyIdNavigation.primaryContactEmail,
        dto.familyIdNavigation.primaryContactFirstName,
        dto.familyIdNavigation.primaryContactLastName,
        dto.familyIdNavigation.primaryContactPhone
      );
    }
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
    <Hash>e752fcfe7d02a5666b9bc54a0904c989</Hash>
</Codenesium>*/