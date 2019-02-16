import * as Api from '../../api/models';
import CountryRequirementViewModel from './countryRequirementViewModel';
import CountryViewModel from '../country/countryViewModel';
export default class CountryRequirementMapper {
  mapApiResponseToViewModel(
    dto: Api.CountryRequirementClientResponseModel
  ): CountryRequirementViewModel {
    let response = new CountryRequirementViewModel();
    response.setProperties(dto.countryId, dto.detail, dto.id);

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
    response.setProperties(model.countryId, model.detail, model.id);
    return response;
  }
}


/*<Codenesium>
    <Hash>5aa6394858e26d09d6658b33b773e924</Hash>
</Codenesium>*/