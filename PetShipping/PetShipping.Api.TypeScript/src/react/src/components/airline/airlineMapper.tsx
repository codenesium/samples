import * as Api from '../../api/models';
import AirlineViewModel from  './airlineViewModel';
export default class AirlineMapper {
    
	mapApiResponseToViewModel(dto: Api.AirlineClientResponseModel) : AirlineViewModel 
	{
		let response = new AirlineViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AirlineViewModel) : Api.AirlineClientRequestModel
	{
		let response = new Api.AirlineClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>3b84ddf6a7a4cd714fabeda35eb6811d</Hash>
</Codenesium>*/