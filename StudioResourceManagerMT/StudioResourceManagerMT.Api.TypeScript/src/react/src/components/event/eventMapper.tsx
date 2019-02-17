import * as Api from '../../api/models';
import EventViewModel from './eventViewModel';
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
      dto.studentNote,
      dto.teacherNote
    );

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
      model.studentNote,
      model.teacherNote
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>84fb7d124945cc1635d548a59c80322a</Hash>
</Codenesium>*/