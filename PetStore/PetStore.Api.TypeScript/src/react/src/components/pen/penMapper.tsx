import * as Api from '../../api/models';
import PenViewModel from  './penViewModel';
export default class PenMapper {
    
	mapApiResponseToViewModel(dto: Api.PenClientResponseModel) : PenViewModel 
	{
		let response = new PenViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PenViewModel) : Api.PenClientRequestModel
	{
		let response = new Api.PenClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>a8d528a7eef35144edbd834021c08da6</Hash>
</Codenesium>*/