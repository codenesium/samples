import * as Api from '../../api/models';
import SaleViewModel from './saleViewModel';
import TransactionViewModel from '../transaction/transactionViewModel';
export default class SaleMapper {
  mapApiResponseToViewModel(dto: Api.SaleClientResponseModel): SaleViewModel {
    let response = new SaleViewModel();
    response.setProperties(
      dto.id,
      dto.ipAddress,
      dto.notes,
      dto.saleDate,
      dto.transactionId
    );

    if (dto.transactionIdNavigation != null) {
      response.transactionIdNavigation = new TransactionViewModel();
      response.transactionIdNavigation.setProperties(
        dto.transactionIdNavigation.amount,
        dto.transactionIdNavigation.gatewayConfirmationNumber,
        dto.transactionIdNavigation.id,
        dto.transactionIdNavigation.transactionStatusId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: SaleViewModel): Api.SaleClientRequestModel {
    let response = new Api.SaleClientRequestModel();
    response.setProperties(
      model.id,
      model.ipAddress,
      model.notes,
      model.saleDate,
      model.transactionId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>1bfe9e101185d6b08bf939cc390a4957</Hash>
</Codenesium>*/