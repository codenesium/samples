import * as Api from '../../api/models';
import CommentsViewModel from  './commentsViewModel';
	import PostsViewModel from '../posts/postsViewModel'
		import UsersViewModel from '../users/usersViewModel'
	export default class CommentsMapper {
    
	mapApiResponseToViewModel(dto: Api.CommentsClientResponseModel) : CommentsViewModel 
	{
		let response = new CommentsViewModel();
		response.setProperties(dto.creationDate,dto.id,dto.postId,dto.score,dto.text,dto.userId);
		
						if(dto.postIdNavigation != null)
				{
				  response.postIdNavigation = new PostsViewModel();
				  response.postIdNavigation.setProperties(
				  dto.postIdNavigation.acceptedAnswerId,dto.postIdNavigation.answerCount,dto.postIdNavigation.body,dto.postIdNavigation.closedDate,dto.postIdNavigation.commentCount,dto.postIdNavigation.communityOwnedDate,dto.postIdNavigation.creationDate,dto.postIdNavigation.favoriteCount,dto.postIdNavigation.id,dto.postIdNavigation.lastActivityDate,dto.postIdNavigation.lastEditDate,dto.postIdNavigation.lastEditorDisplayName,dto.postIdNavigation.lastEditorUserId,dto.postIdNavigation.ownerUserId,dto.postIdNavigation.parentId,dto.postIdNavigation.postTypeId,dto.postIdNavigation.score,dto.postIdNavigation.tag,dto.postIdNavigation.title,dto.postIdNavigation.viewCount
				  );
				}
							if(dto.userIdNavigation != null)
				{
				  response.userIdNavigation = new UsersViewModel();
				  response.userIdNavigation.setProperties(
				  dto.userIdNavigation.aboutMe,dto.userIdNavigation.accountId,dto.userIdNavigation.age,dto.userIdNavigation.creationDate,dto.userIdNavigation.displayName,dto.userIdNavigation.downVote,dto.userIdNavigation.emailHash,dto.userIdNavigation.id,dto.userIdNavigation.lastAccessDate,dto.userIdNavigation.location,dto.userIdNavigation.reputation,dto.userIdNavigation.upVote,dto.userIdNavigation.view,dto.userIdNavigation.websiteUrl
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CommentsViewModel) : Api.CommentsClientRequestModel
	{
		let response = new Api.CommentsClientRequestModel();
		response.setProperties(model.creationDate,model.id,model.postId,model.score,model.text,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>96dd801c2e1edbb49e69b47eace0c2c0</Hash>
</Codenesium>*/