import * as Api from '../../api/models';
import LocationViewModel from './locationViewModel';
export default class LocationMapper {
  mapApiResponseToViewModel(
    dto: Api.LocationClientResponseModel
  ): LocationViewModel {
    let response = new LocationViewModel();
    response.setProperties(
      dto.gpsLat,
      dto.gpsLong,
      dto.locationId,
      dto.locationName
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: LocationViewModel
  ): Api.LocationClientRequestModel {
    let response = new Api.LocationClientRequestModel();
    response.setProperties(
      model.gpsLat,
      model.gpsLong,
      model.locationId,
      model.locationName
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>21cc77e29ac2e7605a4b76e4326a43c2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/