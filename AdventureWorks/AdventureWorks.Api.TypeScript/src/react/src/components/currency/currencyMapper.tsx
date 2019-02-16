import * as Api from '../../api/models';
import CurrencyViewModel from './currencyViewModel';

export default class CurrencyMapper {
  mapApiResponseToViewModel(
    dto: Api.CurrencyClientResponseModel
  ): CurrencyViewModel {
    let response = new CurrencyViewModel();
    response.setProperties(dto.currencyCode, dto.modifiedDate, dto.name);
    return response;
  }

  mapViewModelToApiRequest(
    model: CurrencyViewModel
  ): Api.CurrencyClientRequestModel {
    let response = new Api.CurrencyClientRequestModel();
    response.setProperties(model.currencyCode, model.modifiedDate, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>4672325f1e1f981a1d9fb3f128207093</Hash>
</Codenesium>*/