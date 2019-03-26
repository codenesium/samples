import * as Api from '../../api/models';
import EventTeacherViewModel from './eventTeacherViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';
export default class EventTeacherMapper {
  mapApiResponseToViewModel(
    dto: Api.EventTeacherClientResponseModel
  ): EventTeacherViewModel {
    let response = new EventTeacherViewModel();
    response.setProperties(dto.id, dto.teacherId);

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
    response.setProperties(model.id, model.teacherId);
    return response;
  }
}


/*<Codenesium>
    <Hash>ddf935a0e903cad171587bced8025bea</Hash>
</Codenesium>*/