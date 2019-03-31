import * as Api from '../../api/models';
import EventTeacherViewModel from './eventTeacherViewModel';
import EventViewModel from '../event/eventViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';
export default class EventTeacherMapper {
  mapApiResponseToViewModel(
    dto: Api.EventTeacherClientResponseModel
  ): EventTeacherViewModel {
    let response = new EventTeacherViewModel();
    response.setProperties(dto.eventId, dto.id, dto.teacherId);

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
    if (dto.teacherIdNavigation != null) {
      response.teacherIdNavigation = new TeacherViewModel();
      response.teacherIdNavigation.setProperties(
        dto.teacherIdNavigation.birthday,
        dto.teacherIdNavigation.email,
        dto.teacherIdNavigation.firstName,
        dto.teacherIdNavigation.id,
        dto.teacherIdNavigation.lastName,
        dto.teacherIdNavigation.phone,
        dto.teacherIdNavigation.userId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: EventTeacherViewModel
  ): Api.EventTeacherClientRequestModel {
    let response = new Api.EventTeacherClientRequestModel();
    response.setProperties(model.eventId, model.id, model.teacherId);
    return response;
  }
}


/*<Codenesium>
    <Hash>1bb6781feef0099d8e0bcaf32b25e059</Hash>
</Codenesium>*/