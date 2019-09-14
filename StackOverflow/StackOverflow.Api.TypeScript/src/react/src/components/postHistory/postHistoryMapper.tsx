import * as Api from '../../api/models';
import PostHistoryViewModel from './postHistoryViewModel';
import PostHistoryTypeViewModel from '../postHistoryType/postHistoryTypeViewModel';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';
export default class PostHistoryMapper {
  mapApiResponseToViewModel(
    dto: Api.PostHistoryClientResponseModel
  ): PostHistoryViewModel {
    let response = new PostHistoryViewModel();
    response.setProperties(
      dto.comment,
      dto.creationDate,
      dto.id,
      dto.postHistoryTypeId,
      dto.postId,
      dto.revisionGUID,
      dto.text,
      dto.userDisplayName,
      dto.userId
    );

    if (dto.postHistoryTypeIdNavigation != null) {
      response.postHistoryTypeIdNavigation = new PostHistoryTypeViewModel();
      response.postHistoryTypeIdNavigation.setProperties(
        dto.postHistoryTypeIdNavigation.id,
        dto.postHistoryTypeIdNavigation.rwType
      );
    }
    if (dto.postIdNavigation != null) {
      response.postIdNavigation = new PostViewModel();
      response.postIdNavigation.setProperties(
        dto.postIdNavigation.acceptedAnswerId,
        dto.postIdNavigation.answerCount,
        dto.postIdNavigation.body,
        dto.postIdNavigation.closedDate,
        dto.postIdNavigation.commentCount,
        dto.postIdNavigation.communityOwnedDate,
        dto.postIdNavigation.creationDate,
        dto.postIdNavigation.favoriteCount,
        dto.postIdNavigation.id,
        dto.postIdNavigation.lastActivityDate,
        dto.postIdNavigation.lastEditDate,
        dto.postIdNavigation.lastEditorDisplayName,
        dto.postIdNavigation.lastEditorUserId,
        dto.postIdNavigation.ownerUserId,
        dto.postIdNavigation.parentId,
        dto.postIdNavigation.postTypeId,
        dto.postIdNavigation.score,
        dto.postIdNavigation.tag,
        dto.postIdNavigation.title,
        dto.postIdNavigation.viewCount
      );
    }
    if (dto.userIdNavigation != null) {
      response.userIdNavigation = new UserViewModel();
      response.userIdNavigation.setProperties(
        dto.userIdNavigation.aboutMe,
        dto.userIdNavigation.accountId,
        dto.userIdNavigation.age,
        dto.userIdNavigation.creationDate,
        dto.userIdNavigation.displayName,
        dto.userIdNavigation.downVote,
        dto.userIdNavigation.emailHash,
        dto.userIdNavigation.id,
        dto.userIdNavigation.lastAccessDate,
        dto.userIdNavigation.location,
        dto.userIdNavigation.reputation,
        dto.userIdNavigation.upVote,
        dto.userIdNavigation.view,
        dto.userIdNavigation.websiteUrl
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PostHistoryViewModel
  ): Api.PostHistoryClientRequestModel {
    let response = new Api.PostHistoryClientRequestModel();
    response.setProperties(
      model.comment,
      model.creationDate,
      model.id,
      model.postHistoryTypeId,
      model.postId,
      model.revisionGUID,
      model.text,
      model.userDisplayName,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>57b18e30561ffcea28982dd07402cd8d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/