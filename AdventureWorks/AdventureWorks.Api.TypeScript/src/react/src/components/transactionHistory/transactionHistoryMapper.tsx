import * as Api from '../../api/models';
import TransactionHistoryViewModel from './transactionHistoryViewModel';

export default class TransactionHistoryMapper {
  mapApiResponseToViewModel(
    dto: Api.TransactionHistoryClientResponseModel
  ): TransactionHistoryViewModel {
    let response = new TransactionHistoryViewModel();
    response.setProperties(
      dto.actualCost,
      dto.modifiedDate,
      dto.productID,
      dto.quantity,
      dto.referenceOrderID,
      dto.referenceOrderLineID,
      dto.transactionDate,
      dto.transactionID,
      dto.transactionType
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: TransactionHistoryViewModel
  ): Api.TransactionHistoryClientRequestModel {
    let response = new Api.TransactionHistoryClientRequestModel();
    response.setProperties(
      model.actualCost,
      model.modifiedDate,
      model.productID,
      model.quantity,
      model.referenceOrderID,
      model.referenceOrderLineID,
      model.transactionDate,
      model.transactionID,
      model.transactionType
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>1ee0a8dd5d12a44deb08f811d2836a06</Hash>
</Codenesium>*/