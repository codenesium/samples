import * as Api from '../../api/models';
import IllustrationViewModel from  './illustrationViewModel';
export default class IllustrationMapper {
    
	mapApiResponseToViewModel(dto: Api.IllustrationClientResponseModel) : IllustrationViewModel 
	{
		let response = new IllustrationViewModel();
		response.setProperties(dto.diagram,dto.illustrationID,dto.modifiedDate);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: IllustrationViewModel) : Api.IllustrationClientRequestModel
	{
		let response = new Api.IllustrationClientRequestModel();
		response.setProperties(model.diagram,model.illustrationID,model.modifiedDate);
		return response;
	}
};

/*<Codenesium>
    <Hash>bad3d7cb6c5411287ba41c361332ef69</Hash>
</Codenesium>*/