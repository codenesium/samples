import * as Api from '../../api/models';
import DestinationViewModel from './destinationViewModel';
import CountryViewModel from '../country/countryViewModel';
export default class DestinationMapper {
  mapApiResponseToViewModel(
    dto: Api.DestinationClientResponseModel
  ): DestinationViewModel {
    let response = new DestinationViewModel();
    response.setProperties(dto.countryId, dto.id, dto.name, dto.order);

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
    model: DestinationViewModel
  ): Api.DestinationClientRequestModel {
    let response = new Api.DestinationClientRequestModel();
    response.setProperties(model.countryId, model.id, model.name, model.order);
    return response;
  }
}


/*<Codenesium>
    <Hash>c46cecabb3bfea879110f783df3973f3</Hash>
</Codenesium>*/