import * as Api from '../../api/models';
import TransactionStatuViewModel from './transactionStatuViewModel';
export default class TransactionStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.TransactionStatuClientResponseModel
  ): TransactionStatuViewModel {
    let response = new TransactionStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: TransactionStatuViewModel
  ): Api.TransactionStatuClientRequestModel {
    let response = new Api.TransactionStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>445d94f1d3afe67d60618707ae2c6a82</Hash>
</Codenesium>*/