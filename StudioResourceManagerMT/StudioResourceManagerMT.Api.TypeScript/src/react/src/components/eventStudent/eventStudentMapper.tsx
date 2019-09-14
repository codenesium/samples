import * as Api from '../../api/models';
import EventStudentViewModel from './eventStudentViewModel';
import EventViewModel from '../event/eventViewModel';
import StudentViewModel from '../student/studentViewModel';
export default class EventStudentMapper {
  mapApiResponseToViewModel(
    dto: Api.EventStudentClientResponseModel
  ): EventStudentViewModel {
    let response = new EventStudentViewModel();
    response.setProperties(dto.eventId, dto.id, dto.studentId);

    if (dto.eventIdNavigation != null) {
      response.eventIdNavigation = new EventViewModel();
      response.eventIdNavigation.setProperties(
        dto.eventIdNavigation.actualEndDate,
        dto.eventIdNavigation.actualStartDate,
        dto.eventIdNavigation.billAmount,
        dto.eventIdNavigation.eventStatusId,
        dto.eventIdNavigation.id,
        dto.eventIdNavigation.scheduledEndDate,
        dto.eventIdNavigation.scheduledStartDate,
        dto.eventIdNavigation.studentNotes,
        dto.eventIdNavigation.teacherNotes
      );
    }
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
    response.setProperties(model.eventId, model.id, model.studentId);
    return response;
  }
}


/*<Codenesium>
    <Hash>37e07bb663f3476e2b62146fd3cb9bbb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/