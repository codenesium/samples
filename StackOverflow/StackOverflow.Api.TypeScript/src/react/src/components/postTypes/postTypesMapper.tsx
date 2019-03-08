import * as Api from '../../api/models';
import PostTypesViewModel from  './postTypesViewModel';
export default class PostTypesMapper {
    
	mapApiResponseToViewModel(dto: Api.PostTypesClientResponseModel) : PostTypesViewModel 
	{
		let response = new PostTypesViewModel();
		response.setProperties(dto.id,dto.rwType);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostTypesViewModel) : Api.PostTypesClientRequestModel
	{
		let response = new Api.PostTypesClientRequestModel();
		response.setProperties(model.id,model.rwType);
		return response;
	}
};

/*<Codenesium>
    <Hash>952af6d60c404233141f18544c7d8074</Hash>
</Codenesium>*/