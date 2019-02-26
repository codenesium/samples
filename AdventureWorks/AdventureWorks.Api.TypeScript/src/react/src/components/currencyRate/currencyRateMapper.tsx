import * as Api from '../../api/models';
import CurrencyRateViewModel from './currencyRateViewModel';
import CurrencyViewModel from '../currency/currencyViewModel';
export default class CurrencyRateMapper {
  mapApiResponseToViewModel(
    dto: Api.CurrencyRateClientResponseModel
  ): CurrencyRateViewModel {
    let response = new CurrencyRateViewModel();
    response.setProperties(
      dto.averageRate,
      dto.currencyRateDate,
      dto.currencyRateID,
      dto.endOfDayRate,
      dto.fromCurrencyCode,
      dto.modifiedDate,
      dto.toCurrencyCode
    );

    if (dto.fromCurrencyCodeNavigation != null) {
      response.fromCurrencyCodeNavigation = new CurrencyViewModel();
      response.fromCurrencyCodeNavigation.setProperties(
        dto.fromCurrencyCodeNavigation.currencyCode,
        dto.fromCurrencyCodeNavigation.modifiedDate,
        dto.fromCurrencyCodeNavigation.name
      );
    }
    if (dto.toCurrencyCodeNavigation != null) {
      response.toCurrencyCodeNavigation = new CurrencyViewModel();
      response.toCurrencyCodeNavigation.setProperties(
        dto.toCurrencyCodeNavigation.currencyCode,
        dto.toCurrencyCodeNavigation.modifiedDate,
        dto.toCurrencyCodeNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: CurrencyRateViewModel
  ): Api.CurrencyRateClientRequestModel {
    let response = new Api.CurrencyRateClientRequestModel();
    response.setProperties(
      model.averageRate,
      model.currencyRateDate,
      model.currencyRateID,
      model.endOfDayRate,
      model.fromCurrencyCode,
      model.modifiedDate,
      model.toCurrencyCode
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>9f2d592e8720bd7ef424a771c5c4d4a0</Hash>
</Codenesium>*/