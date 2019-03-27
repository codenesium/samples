import * as Api from '../../api/models';
import EventViewModel from './eventViewModel';
import EventStatusViewModel from '../eventStatus/eventStatusViewModel';
export default class EventMapper {
  mapApiResponseToViewModel(dto: Api.EventClientResponseModel): EventViewModel {
    let response = new EventViewModel();
    response.setProperties(
      dto.actualEndDate,
      dto.actualStartDate,
      dto.billAmount,
      dto.eventStatusId,
      dto.id,
      dto.scheduledEndDate,
      dto.scheduledStartDate,
      dto.studentNotes,
      dto.teacherNotes
    );

    if (dto.eventStatusIdNavigation != null) {
      response.eventStatusIdNavigation = new EventStatusViewModel();
      response.eventStatusIdNavigation.setProperties(
        dto.eventStatusIdNavigation.id,
        dto.eventStatusIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: EventViewModel): Api.EventClientRequestModel {
    let response = new Api.EventClientRequestModel();
    response.setProperties(
      model.actualEndDate,
      model.actualStartDate,
      model.billAmount,
      model.eventStatusId,
      model.id,
      model.scheduledEndDate,
      model.scheduledStartDate,
      model.studentNotes,
      model.teacherNotes
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b6db3b131602c89e143bf3364c38002e</Hash>
</Codenesium>*/