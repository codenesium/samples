import * as Api from '../../api/models';
import CountryRegionViewModel from './countryRegionViewModel';

export default class CountryRegionMapper {
  mapApiResponseToViewModel(
    dto: Api.CountryRegionClientResponseModel
  ): CountryRegionViewModel {
    let response = new CountryRegionViewModel();
    response.setProperties(dto.countryRegionCode, dto.modifiedDate, dto.name);
    return response;
  }

  mapViewModelToApiRequest(
    model: CountryRegionViewModel
  ): Api.CountryRegionClientRequestModel {
    let response = new Api.CountryRegionClientRequestModel();
    response.setProperties(
      model.countryRegionCode,
      model.modifiedDate,
      model.name
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>11ae32db18e074a7305e2f167da28546</Hash>
</Codenesium>*/