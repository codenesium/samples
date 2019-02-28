import * as Api from '../../api/models';
import SaleTicketViewModel from './saleTicketViewModel';
import SaleViewModel from '../sale/saleViewModel';
import TicketViewModel from '../ticket/ticketViewModel';
export default class SaleTicketMapper {
  mapApiResponseToViewModel(
    dto: Api.SaleTicketClientResponseModel
  ): SaleTicketViewModel {
    let response = new SaleTicketViewModel();
    response.setProperties(dto.id, dto.saleId, dto.ticketId);

    if (dto.saleIdNavigation != null) {
      response.saleIdNavigation = new SaleViewModel();
      response.saleIdNavigation.setProperties(
        dto.saleIdNavigation.id,
        dto.saleIdNavigation.ipAddress,
        dto.saleIdNavigation.note,
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
    model: SaleTicketViewModel
  ): Api.SaleTicketClientRequestModel {
    let response = new Api.SaleTicketClientRequestModel();
    response.setProperties(model.id, model.saleId, model.ticketId);
    return response;
  }
}


/*<Codenesium>
    <Hash>5322415e70287bfafc42e61235679609</Hash>
</Codenesium>*/