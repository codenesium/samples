import * as Api from '../../api/models';
import TicketViewModel from './ticketViewModel';
import TicketStatusViewModel from '../ticketStatus/ticketStatusViewModel';
export default class TicketMapper {
  mapApiResponseToViewModel(
    dto: Api.TicketClientResponseModel
  ): TicketViewModel {
    let response = new TicketViewModel();
    response.setProperties(dto.id, dto.publicId, dto.ticketStatusId);

    if (dto.ticketStatusIdNavigation != null) {
      response.ticketStatusIdNavigation = new TicketStatusViewModel();
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
    <Hash>01258126e0475747bdeb1e8fcff48548</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/