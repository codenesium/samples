import * as Api from '../../api/models';
import CountryRequirementViewModel from './countryRequirementViewModel';
import CountryViewModel from '../country/countryViewModel';
export default class CountryRequirementMapper {
  mapApiResponseToViewModel(
    dto: Api.CountryRequirementClientResponseModel
  ): CountryRequirementViewModel {
    let response = new CountryRequirementViewModel();
    response.setProperties(dto.countryId, dto.details, dto.id);

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
    model: CountryRequirementViewModel
  ): Api.CountryRequirementClientRequestModel {
    let response = new Api.CountryRequirementClientRequestModel();
    response.setProperties(model.countryId, model.details, model.id);
    return response;
  }
}


/*<Codenesium>
    <Hash>f6ffc8eac744d4f95356084937cc178e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/