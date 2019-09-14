import * as Api from '../../api/models';
import SaleTicketsViewModel from './saleTicketsViewModel';
import SaleViewModel from '../sale/saleViewModel';
import TicketViewModel from '../ticket/ticketViewModel';
export default class SaleTicketsMapper {
  mapApiResponseToViewModel(
    dto: Api.SaleTicketsClientResponseModel
  ): SaleTicketsViewModel {
    let response = new SaleTicketsViewModel();
    response.setProperties(dto.id, dto.saleId, dto.ticketId);

    if (dto.saleIdNavigation != null) {
      response.saleIdNavigation = new SaleViewModel();
      response.saleIdNavigation.setProperties(
        dto.saleIdNavigation.id,
        dto.saleIdNavigation.ipAddress,
        dto.saleIdNavigation.notes,
        dto.saleIdNavigation.saleDate,
        dto.saleIdNavigation.transactionId
      );
    }
    if (dto.ticketIdNavigation != null) {
      response.ticketIdNavigation = new TicketViewModel();
      response.ticketIdNavigation.setProperties(
        dto.ticketIdNavigation.id,
        dto.ticketIdNavigation.publicId,
        dto.ticketIdNavigation.ticketStatusId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: SaleTicketsViewModel
  ): Api.SaleTicketsClientRequestModel {
    let response = new Api.SaleTicketsClientRequestModel();
    response.setProperties(model.id, model.saleId, model.ticketId);
    return response;
  }
}


/*<Codenesium>
    <Hash>00c55b8f7471fbcce683b68735d325ac</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/