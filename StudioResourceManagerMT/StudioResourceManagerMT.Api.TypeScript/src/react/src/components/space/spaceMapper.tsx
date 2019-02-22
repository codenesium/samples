import * as Api from '../../api/models';
import SpaceViewModel from  './spaceViewModel';
export default class SpaceMapper {
    
	mapApiResponseToViewModel(dto: Api.SpaceClientResponseModel) : SpaceViewModel 
	{
		let response = new SpaceViewModel();
		response.setProperties(dto.description,dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SpaceViewModel) : Api.SpaceClientRequestModel
	{
		let response = new Api.SpaceClientRequestModel();
		response.setProperties(model.description,model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>95cef6c23ee937a33777dd8d7244e062</Hash>
</Codenesium>*/