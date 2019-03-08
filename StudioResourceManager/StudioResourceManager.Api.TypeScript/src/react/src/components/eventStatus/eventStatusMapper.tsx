import * as Api from '../../api/models';
import EventStatusViewModel from  './eventStatusViewModel';
export default class EventStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.EventStatusClientResponseModel) : EventStatusViewModel 
	{
		let response = new EventStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: EventStatusViewModel) : Api.EventStatusClientRequestModel
	{
		let response = new Api.EventStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>ea60a27741785bf13e7cca4611a632fb</Hash>
</Codenesium>*/