import * as Api from '../../api/models';
import CityViewModel from './cityViewModel';
import ProvinceViewModel from '../province/provinceViewModel';
export default class CityMapper {
  mapApiResponseToViewModel(dto: Api.CityClientResponseModel): CityViewModel {
    let response = new CityViewModel();
    response.setProperties(dto.id, dto.name, dto.provinceId);

    if (dto.provinceIdNavigation != null) {
      response.provinceIdNavigation = new ProvinceViewModel();
      response.provinceIdNavigation.setProperties(
        dto.provinceIdNavigation.countryId,
        dto.provinceIdNavigation.id,
        dto.provinceIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: CityViewModel): Api.CityClientRequestModel {
    let response = new Api.CityClientRequestModel();
    response.setProperties(model.id, model.name, model.provinceId);
    return response;
  }
}


/*<Codenesium>
    <Hash>d34e456e38becfe86aab842c25d8633b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/