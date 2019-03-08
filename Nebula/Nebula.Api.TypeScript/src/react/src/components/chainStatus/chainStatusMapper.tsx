import * as Api from '../../api/models';
import ChainStatusViewModel from  './chainStatusViewModel';
export default class ChainStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.ChainStatusClientResponseModel) : ChainStatusViewModel 
	{
		let response = new ChainStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ChainStatusViewModel) : Api.ChainStatusClientRequestModel
	{
		let response = new Api.ChainStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>9f5a9b33316d251f53a77c6b7a3c61d7</Hash>
</Codenesium>*/