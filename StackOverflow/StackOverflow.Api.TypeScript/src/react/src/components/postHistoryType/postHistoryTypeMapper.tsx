import * as Api from '../../api/models';
import PostHistoryTypeViewModel from  './postHistoryTypeViewModel';
export default class PostHistoryTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.PostHistoryTypeClientResponseModel) : PostHistoryTypeViewModel 
	{
		let response = new PostHistoryTypeViewModel();
		response.setProperties(dto.id,dto.rwType);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostHistoryTypeViewModel) : Api.PostHistoryTypeClientRequestModel
	{
		let response = new Api.PostHistoryTypeClientRequestModel();
		response.setProperties(model.id,model.rwType);
		return response;
	}
};

/*<Codenesium>
    <Hash>008fbb2482095048644f8630230b66d9</Hash>
</Codenesium>*/