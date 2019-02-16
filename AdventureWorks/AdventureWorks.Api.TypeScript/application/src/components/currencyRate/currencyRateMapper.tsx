import * as Api from '../../api/models';
import CurrencyRateViewModel from './currencyRateViewModel';

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
    <Hash>f44107e4586aee42dbb6e52a14174984</Hash>
</Codenesium>*/