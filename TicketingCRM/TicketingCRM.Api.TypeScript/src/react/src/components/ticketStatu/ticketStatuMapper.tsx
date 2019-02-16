import * as Api from '../../api/models';
import TicketStatuViewModel from './ticketStatuViewModel';
export default class TicketStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.TicketStatuClientResponseModel
  ): TicketStatuViewModel {
    let response = new TicketStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: TicketStatuViewModel
  ): Api.TicketStatuClientRequestModel {
    let response = new Api.TicketStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>ebba2a7c9d564eee6c2879faf966e8b9</Hash>
</Codenesium>*/