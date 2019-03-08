import * as Api from '../../api/models';
import PaymentTypeViewModel from './paymentTypeViewModel';
export default class PaymentTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PaymentTypeClientResponseModel
  ): PaymentTypeViewModel {
    let response = new PaymentTypeViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PaymentTypeViewModel
  ): Api.PaymentTypeClientRequestModel {
    let response = new Api.PaymentTypeClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>feabac69328f5b8a7be4f9f63a20d489</Hash>
</Codenesium>*/