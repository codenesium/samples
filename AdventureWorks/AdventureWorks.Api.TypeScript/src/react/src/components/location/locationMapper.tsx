import * as Api from '../../api/models';
import LocationViewModel from './locationViewModel';
export default class LocationMapper {
  mapApiResponseToViewModel(
    dto: Api.LocationClientResponseModel
  ): LocationViewModel {
    let response = new LocationViewModel();
    response.setProperties(
      dto.availability,
      dto.costRate,
      dto.locationID,
      dto.modifiedDate,
      dto.name
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: LocationViewModel
  ): Api.LocationClientRequestModel {
    let response = new Api.LocationClientRequestModel();
    response.setProperties(
      model.availability,
      model.costRate,
      model.locationID,
      model.modifiedDate,
      model.name
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>05c2eed3bb95cb50fab39a24a8384902</Hash>
</Codenesium>*/