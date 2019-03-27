import * as Api from '../../api/models';
import EventTeacherViewModel from './eventTeacherViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';
export default class EventTeacherMapper {
  mapApiResponseToViewModel(
    dto: Api.EventTeacherClientResponseModel
  ): EventTeacherViewModel {
    let response = new EventTeacherViewModel();
    response.setProperties(dto.eventId, dto.teacherId);

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
    response.setProperties(model.eventId, model.teacherId);
    return response;
  }
}


/*<Codenesium>
    <Hash>2acb2fd6d3ddae8f95c51f7ec6a137ef</Hash>
</Codenesium>*/