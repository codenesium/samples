import * as Api from '../../api/models';
import ProvinceViewModel from './provinceViewModel';
import CountryViewModel from '../country/countryViewModel';
export default class ProvinceMapper {
  mapApiResponseToViewModel(
    dto: Api.ProvinceClientResponseModel
  ): ProvinceViewModel {
    let response = new ProvinceViewModel();
    response.setProperties(dto.countryId, dto.id, dto.name);

    if (dto.countryIdNavigation != null) {
      response.countryIdNavigation = new CountryViewModel();
      response.countryIdNavigation.setProperties(
        dto.countryIdNavigation.id,
        dto.countryIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: ProvinceViewModel
  ): Api.ProvinceClientRequestModel {
    let response = new Api.ProvinceClientRequestModel();
    response.setProperties(model.countryId, model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>5d3e5b72ded48fa1fd5e912348177402</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/