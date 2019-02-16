import * as Api from '../../api/models';
import PostHistoryViewModel from  './postHistoryViewModel';
export default class PostHistoryMapper {
    
	mapApiResponseToViewModel(dto: Api.PostHistoryClientResponseModel) : PostHistoryViewModel 
	{
		let response = new PostHistoryViewModel();
		response.setProperties(dto.comment,dto.creationDate,dto.id,dto.postHistoryTypeId,dto.postId,dto.revisionGUID,dto.text,dto.userDisplayName,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostHistoryViewModel) : Api.PostHistoryClientRequestModel
	{
		let response = new Api.PostHistoryClientRequestModel();
		response.setProperties(model.comment,model.creationDate,model.id,model.postHistoryTypeId,model.postId,model.revisionGUID,model.text,model.userDisplayName,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>34d9c7260dbf6a0e1839eb6d27ac6458</Hash>
</Codenesium>*/