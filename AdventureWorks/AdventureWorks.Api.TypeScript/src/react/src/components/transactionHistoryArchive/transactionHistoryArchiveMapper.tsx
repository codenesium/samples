import * as Api from '../../api/models';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';

export default class TransactionHistoryArchiveMapper {
  mapApiResponseToViewModel(
    dto: Api.TransactionHistoryArchiveClientResponseModel
  ): TransactionHistoryArchiveViewModel {
    let response = new TransactionHistoryArchiveViewModel();
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
    model: TransactionHistoryArchiveViewModel
  ): Api.TransactionHistoryArchiveClientRequestModel {
    let response = new Api.TransactionHistoryArchiveClientRequestModel();
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
    <Hash>6a816e01932a9a6d62563e86cef09ed4</Hash>
</Codenesium>*/