import * as Api from '../../api/models';
import EventStudentViewModel from './eventStudentViewModel';
import StudentViewModel from '../student/studentViewModel';
export default class EventStudentMapper {
  mapApiResponseToViewModel(
    dto: Api.EventStudentClientResponseModel
  ): EventStudentViewModel {
    let response = new EventStudentViewModel();
    response.setProperties(dto.eventId, dto.studentId);

    if (dto.studentIdNavigation != null) {
      response.studentIdNavigation = new StudentViewModel();
      response.studentIdNavigation.setProperties(
        dto.studentIdNavigation.birthday,
        dto.studentIdNavigation.email,
        dto.studentIdNavigation.emailRemindersEnabled,
        dto.studentIdNavigation.familyId,
        dto.studentIdNavigation.firstName,
        dto.studentIdNavigation.id,
        dto.studentIdNavigation.isAdult,
        dto.studentIdNavigation.lastName,
        dto.studentIdNavigation.phone,
        dto.studentIdNavigation.smsRemindersEnabled,
        dto.studentIdNavigation.userId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: EventStudentViewModel
  ): Api.EventStudentClientRequestModel {
    let response = new Api.EventStudentClientRequestModel();
    response.setProperties(model.eventId, model.studentId);
    return response;
  }
}


/*<Codenesium>
    <Hash>edf52d9c31657ba9fc051b42451a9777</Hash>
</Codenesium>*/