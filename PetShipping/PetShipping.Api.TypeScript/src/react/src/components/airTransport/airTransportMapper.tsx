import * as Api from '../../api/models';
import AirTransportViewModel from  './airTransportViewModel';
	import HandlerViewModel from '../handler/handlerViewModel'
	export default class AirTransportMapper {
    
	mapApiResponseToViewModel(dto: Api.AirTransportClientResponseModel) : AirTransportViewModel 
	{
		let response = new AirTransportViewModel();
		response.setProperties(dto.airlineId,dto.flightNumber,dto.handlerId,dto.id,dto.landDate,dto.pipelineStepId,dto.takeoffDate);
		
						if(dto.handlerIdNavigation != null)
				{
				  response.handlerIdNavigation = new HandlerViewModel();
				  response.handlerIdNavigation.setProperties(
				  dto.handlerIdNavigation.countryId,dto.handlerIdNavigation.email,dto.handlerIdNavigation.firstName,dto.handlerIdNavigation.id,dto.handlerIdNavigation.lastName,dto.handlerIdNavigation.phone
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AirTransportViewModel) : Api.AirTransportClientRequestModel
	{
		let response = new Api.AirTransportClientRequestModel();
		response.setProperties(model.airlineId,model.flightNumber,model.handlerId,model.id,model.landDate,model.pipelineStepId,model.takeoffDate);
		return response;
	}
};

/*<Codenesium>
    <Hash>55f567a4a9606411e997d22497bccb1d</Hash>
</Codenesium>*/