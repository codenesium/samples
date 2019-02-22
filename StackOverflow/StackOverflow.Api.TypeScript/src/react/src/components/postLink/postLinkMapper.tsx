import * as Api from '../../api/models';
import PostLinkViewModel from  './postLinkViewModel';
export default class PostLinkMapper {
    
	mapApiResponseToViewModel(dto: Api.PostLinkClientResponseModel) : PostLinkViewModel 
	{
		let response = new PostLinkViewModel();
		response.setProperties(dto.creationDate,dto.id,dto.linkTypeId,dto.postId,dto.relatedPostId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostLinkViewModel) : Api.PostLinkClientRequestModel
	{
		let response = new Api.PostLinkClientRequestModel();
		response.setProperties(model.creationDate,model.id,model.linkTypeId,model.postId,model.relatedPostId);
		return response;
	}
};

/*<Codenesium>
    <Hash>b855709f77fcb234543540a6a25306f0</Hash>
</Codenesium>*/