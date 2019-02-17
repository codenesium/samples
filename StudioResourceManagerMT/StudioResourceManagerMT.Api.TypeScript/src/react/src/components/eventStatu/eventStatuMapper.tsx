import * as Api from '../../api/models';
import EventStatuViewModel from  './eventStatuViewModel';
export default class EventStatuMapper {
    
	mapApiResponseToViewModel(dto: Api.EventStatuClientResponseModel) : EventStatuViewModel 
	{
		let response = new EventStatuViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: EventStatuViewModel) : Api.EventStatuClientRequestModel
	{
		let response = new Api.EventStatuClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>0d47d627662ad899f3a3198e7112237b</Hash>
</Codenesium>*/