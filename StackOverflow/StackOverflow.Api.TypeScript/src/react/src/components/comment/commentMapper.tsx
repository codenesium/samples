import * as Api from '../../api/models';
import CommentViewModel from './commentViewModel';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';
export default class CommentMapper {
  mapApiResponseToViewModel(
    dto: Api.CommentClientResponseModel
  ): CommentViewModel {
    let response = new CommentViewModel();
    response.setProperties(
      dto.creationDate,
      dto.id,
      dto.postId,
      dto.score,
      dto.text,
      dto.userId
    );

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
    model: CommentViewModel
  ): Api.CommentClientRequestModel {
    let response = new Api.CommentClientRequestModel();
    response.setProperties(
      model.creationDate,
      model.id,
      model.postId,
      model.score,
      model.text,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>3d932f621928a3ed444196ceda77e388</Hash>
</Codenesium>*/