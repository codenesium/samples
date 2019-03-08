import * as Api from '../../api/models';
import PaymentTypeViewModel from './paymentTypeViewModel';
export default class PaymentTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PaymentTypeClientResponseModel
  ): PaymentTypeViewModel {
    let response = new PaymentTypeViewModel();
    response.setProperties(dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PaymentTypeViewModel
  ): Api.PaymentTypeClientRequestModel {
    let response = new Api.PaymentTypeClientRequestModel();
    response.setProperties(model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>57540d5ff139ba937e587503a7237f0f</Hash>
</Codenesium>*/