import * as Api from '../../api/models';
import CreditCardViewModel from './creditCardViewModel';

export default class CreditCardMapper {
  mapApiResponseToViewModel(
    dto: Api.CreditCardClientResponseModel
  ): CreditCardViewModel {
    let response = new CreditCardViewModel();
    response.setProperties(
      dto.cardNumber,
      dto.cardType,
      dto.creditCardID,
      dto.expMonth,
      dto.expYear,
      dto.modifiedDate
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: CreditCardViewModel
  ): Api.CreditCardClientRequestModel {
    let response = new Api.CreditCardClientRequestModel();
    response.setProperties(
      model.cardNumber,
      model.cardType,
      model.creditCardID,
      model.expMonth,
      model.expYear,
      model.modifiedDate
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2326287a0d651f77d84477ba3c562602</Hash>
</Codenesium>*/