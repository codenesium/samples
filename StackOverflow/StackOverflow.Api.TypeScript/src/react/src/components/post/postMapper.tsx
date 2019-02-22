import * as Api from '../../api/models';
import PostViewModel from  './postViewModel';
export default class PostMapper {
    
	mapApiResponseToViewModel(dto: Api.PostClientResponseModel) : PostViewModel 
	{
		let response = new PostViewModel();
		response.setProperties(dto.acceptedAnswerId,dto.answerCount,dto.body,dto.closedDate,dto.commentCount,dto.communityOwnedDate,dto.creationDate,dto.favoriteCount,dto.id,dto.lastActivityDate,dto.lastEditDate,dto.lastEditorDisplayName,dto.lastEditorUserId,dto.ownerUserId,dto.parentId,dto.postTypeId,dto.score,dto.tag,dto.title,dto.viewCount);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostViewModel) : Api.PostClientRequestModel
	{
		let response = new Api.PostClientRequestModel();
		response.setProperties(model.acceptedAnswerId,model.answerCount,model.body,model.closedDate,model.commentCount,model.communityOwnedDate,model.creationDate,model.favoriteCount,model.id,model.lastActivityDate,model.lastEditDate,model.lastEditorDisplayName,model.lastEditorUserId,model.ownerUserId,model.parentId,model.postTypeId,model.score,model.tag,model.title,model.viewCount);
		return response;
	}
};

/*<Codenesium>
    <Hash>0ef3915c6564087a1b9d3045df3ce319</Hash>
</Codenesium>*/