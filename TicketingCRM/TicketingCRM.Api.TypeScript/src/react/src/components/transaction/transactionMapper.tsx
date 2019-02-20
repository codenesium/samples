import * as Api from '../../api/models';
import TransactionViewModel from './transactionViewModel';
import TransactionStatusViewModel from '../transactionStatus/transactionStatusViewModel';
export default class TransactionMapper {
  mapApiResponseToViewModel(
    dto: Api.TransactionClientResponseModel
  ): TransactionViewModel {
    let response = new TransactionViewModel();
    response.setProperties(
      dto.amount,
      dto.gatewayConfirmationNumber,
      dto.id,
      dto.transactionStatusId
    );

    if (dto.transactionStatusIdNavigation != null) {
      response.transactionStatusIdNavigation = new TransactionStatusViewModel();
      response.transactionStatusIdNavigation.setProperties(
        dto.transactionStatusIdNavigation.id,
        dto.transactionStatusIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: TransactionViewModel
  ): Api.TransactionClientRequestModel {
    let response = new Api.TransactionClientRequestModel();
    response.setProperties(
      model.amount,
      model.gatewayConfirmationNumber,
      model.id,
      model.transactionStatusId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>8fd8ebde15c3a7a3bd4fdfeb052e3c70</Hash>
</Codenesium>*/