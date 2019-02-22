import * as Api from '../../api/models';
import TicketStatusViewModel from  './ticketStatusViewModel';
export default class TicketStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.TicketStatusClientResponseModel) : TicketStatusViewModel 
	{
		let response = new TicketStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TicketStatusViewModel) : Api.TicketStatusClientRequestModel
	{
		let response = new Api.TicketStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>d274786bfd0bbe7db075ac11620a9a03</Hash>
</Codenesium>*/