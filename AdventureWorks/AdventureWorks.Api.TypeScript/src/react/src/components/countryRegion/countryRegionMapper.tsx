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
    <Hash>b655d085079e06ddae688b65bafca867</Hash>
</Codenesium>*/