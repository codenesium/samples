import * as Api from '../../api/models';
import TicketStatusViewModel from './ticketStatusViewModel';
export default class TicketStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.TicketStatusClientResponseModel
  ): TicketStatusViewModel {
    let response = new TicketStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: TicketStatusViewModel
  ): Api.TicketStatusClientRequestModel {
    let response = new Api.TicketStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>71f06f12e18454d06e463e5076b0674e</Hash>
</Codenesium>*/