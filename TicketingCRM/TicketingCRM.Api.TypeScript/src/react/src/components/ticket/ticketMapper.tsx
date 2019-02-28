import * as Api from '../../api/models';
import TicketViewModel from  './ticketViewModel';
	import TicketStatusViewModel from '../ticketStatus/ticketStatusViewModel'
	export default class TicketMapper {
    
	mapApiResponseToViewModel(dto: Api.TicketClientResponseModel) : TicketViewModel 
	{
		let response = new TicketViewModel();
		response.setProperties(dto.id,dto.publicId,dto.ticketStatusId);
		
						if(dto.ticketStatusIdNavigation != null)
				{
				  response.ticketStatusIdNavigation = new TicketStatusViewModel();
				  response.ticketStatusIdNavigation.setProperties(
				  dto.ticketStatusIdNavigation.id,dto.ticketStatusIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TicketViewModel) : Api.TicketClientRequestModel
	{
		let response = new Api.TicketClientRequestModel();
		response.setProperties(model.id,model.publicId,model.ticketStatusId);
		return response;
	}
};

/*<Codenesium>
    <Hash>dde52f7fac53b01d45e50a222da13ed8</Hash>
</Codenesium>*/