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
    <Hash>0cc5384cb73d3d690a6922196e862543</Hash>
</Codenesium>*/