import * as Api from '../api/models';
import EventViewModel from  '../viewmodels/eventViewModel';

export default class EventMapper {
    
	mapApiResponseToViewModel(dto: Api.EventClientResponseModel) : EventViewModel 
	{
		let response = new EventViewModel();
		response.setProperties(dto.actualEndDate,dto.actualStartDate,dto.billAmount,dto.eventStatusId,dto.id,dto.isDeleted,dto.scheduledEndDate,dto.scheduledStartDate,dto.studentNote,dto.teacherNote,dto.tenantId);
		return response;
	}

	mapViewModelToApiRequest(model: EventViewModel) : Api.EventClientRequestModel
	{
		let response = new Api.EventClientRequestModel();
		response.setProperties(model.actualEndDate,model.actualStartDate,model.billAmount,model.eventStatusId,model.id,model.isDeleted,model.scheduledEndDate,model.scheduledStartDate,model.studentNote,model.teacherNote,model.tenantId);
		return response;
	}
};

/*<Codenesium>
    <Hash>fed3274ab58661a34df926187b3ce306</Hash>
</Codenesium>*/