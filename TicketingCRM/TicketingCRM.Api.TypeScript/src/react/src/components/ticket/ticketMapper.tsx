import * as Api from '../../api/models';
import TicketViewModel from './ticketViewModel';
import TicketStatuViewModel from '../ticketStatu/ticketStatuViewModel';
export default class TicketMapper {
  mapApiResponseToViewModel(
    dto: Api.TicketClientResponseModel
  ): TicketViewModel {
    let response = new TicketViewModel();
    response.setProperties(dto.id, dto.publicId, dto.ticketStatusId);

    if (dto.ticketStatusIdNavigation != null) {
      response.ticketStatusIdNavigation = new TicketStatuViewModel();
      response.ticketStatusIdNavigation.setProperties(
        dto.ticketStatusIdNavigation.id,
        dto.ticketStatusIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: TicketViewModel
  ): Api.TicketClientRequestModel {
    let response = new Api.TicketClientRequestModel();
    response.setProperties(model.id, model.publicId, model.ticketStatusId);
    return response;
  }
}


/*<Codenesium>
    <Hash>389aad4be4d6b1f9cb73d21ca1cead3a</Hash>
</Codenesium>*/