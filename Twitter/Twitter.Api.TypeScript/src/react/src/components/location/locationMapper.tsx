import * as Api from '../../api/models';
import LocationViewModel from  './locationViewModel';
export default class LocationMapper {
    
	mapApiResponseToViewModel(dto: Api.LocationClientResponseModel) : LocationViewModel 
	{
		let response = new LocationViewModel();
		response.setProperties(dto.gpsLat,dto.gpsLong,dto.locationId,dto.locationName);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: LocationViewModel) : Api.LocationClientRequestModel
	{
		let response = new Api.LocationClientRequestModel();
		response.setProperties(model.gpsLat,model.gpsLong,model.locationId,model.locationName);
		return response;
	}
};

/*<Codenesium>
    <Hash>cfa5afed4fe7a4dd550dcb402a390c65</Hash>
</Codenesium>*/