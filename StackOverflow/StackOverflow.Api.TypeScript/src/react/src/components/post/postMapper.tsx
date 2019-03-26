import * as Api from '../../api/models';
import PostViewModel from './postViewModel';
import UserViewModel from '../user/userViewModel';
import PostTypeViewModel from '../postType/postTypeViewModel';
export default class PostMapper {
  mapApiResponseToViewModel(dto: Api.PostClientResponseModel): PostViewModel {
    let response = new PostViewModel();
    response.setProperties(
      dto.acceptedAnswerId,
      dto.answerCount,
      dto.body,
      dto.closedDate,
      dto.commentCount,
      dto.communityOwnedDate,
      dto.creationDate,
      dto.favoriteCount,
      dto.id,
      dto.lastActivityDate,
      dto.lastEditDate,
      dto.lastEditorDisplayName,
      dto.lastEditorUserId,
      dto.ownerUserId,
      dto.parentId,
      dto.postTypeId,
      dto.score,
      dto.tag,
      dto.title,
      dto.viewCount
    );

    if (dto.lastEditorUserIdNavigation != null) {
      response.lastEditorUserIdNavigation = new UserViewModel();
      response.lastEditorUserIdNavigation.setProperties(
        dto.lastEditorUserIdNavigation.aboutMe,
        dto.lastEditorUserIdNavigation.accountId,
        dto.lastEditorUserIdNavigation.age,
        dto.lastEditorUserIdNavigation.creationDate,
        dto.lastEditorUserIdNavigation.displayName,
        dto.lastEditorUserIdNavigation.downVote,
        dto.lastEditorUserIdNavigation.emailHash,
        dto.lastEditorUserIdNavigation.id,
        dto.lastEditorUserIdNavigation.lastAccessDate,
        dto.lastEditorUserIdNavigation.location,
        dto.lastEditorUserIdNavigation.reputation,
        dto.lastEditorUserIdNavigation.upVote,
        dto.lastEditorUserIdNavigation.view,
        dto.lastEditorUserIdNavigation.websiteUrl
      );
    }
    if (dto.ownerUserIdNavigation != null) {
      response.ownerUserIdNavigation = new UserViewModel();
      response.ownerUserIdNavigation.setProperties(
        dto.ownerUserIdNavigation.aboutMe,
        dto.ownerUserIdNavigation.accountId,
        dto.ownerUserIdNavigation.age,
        dto.ownerUserIdNavigation.creationDate,
        dto.ownerUserIdNavigation.displayName,
        dto.ownerUserIdNavigation.downVote,
        dto.ownerUserIdNavigation.emailHash,
        dto.ownerUserIdNavigation.id,
        dto.ownerUserIdNavigation.lastAccessDate,
        dto.ownerUserIdNavigation.location,
        dto.ownerUserIdNavigation.reputation,
        dto.ownerUserIdNavigation.upVote,
        dto.ownerUserIdNavigation.view,
        dto.ownerUserIdNavigation.websiteUrl
      );
    }
    if (dto.parentIdNavigation != null) {
      response.parentIdNavigation = new PostViewModel();
      response.parentIdNavigation.setProperties(
        dto.parentIdNavigation.acceptedAnswerId,
        dto.parentIdNavigation.answerCount,
        dto.parentIdNavigation.body,
        dto.parentIdNavigation.closedDate,
        dto.parentIdNavigation.commentCount,
        dto.parentIdNavigation.communityOwnedDate,
        dto.parentIdNavigation.creationDate,
        dto.parentIdNavigation.favoriteCount,
        dto.parentIdNavigation.id,
        dto.parentIdNavigation.lastActivityDate,
        dto.parentIdNavigation.lastEditDate,
        dto.parentIdNavigation.lastEditorDisplayName,
        dto.parentIdNavigation.lastEditorUserId,
        dto.parentIdNavigation.ownerUserId,
        dto.parentIdNavigation.parentId,
        dto.parentIdNavigation.postTypeId,
        dto.parentIdNavigation.score,
        dto.parentIdNavigation.tag,
        dto.parentIdNavigation.title,
        dto.parentIdNavigation.viewCount
      );
    }
    if (dto.postTypeIdNavigation != null) {
      response.postTypeIdNavigation = new PostTypeViewModel();
      response.postTypeIdNavigation.setProperties(
        dto.postTypeIdNavigation.id,
        dto.postTypeIdNavigation.rwType
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: PostViewModel): Api.PostClientRequestModel {
    let response = new Api.PostClientRequestModel();
    response.setProperties(
      model.acceptedAnswerId,
      model.answerCount,
      model.body,
      model.closedDate,
      model.commentCount,
      model.communityOwnedDate,
      model.creationDate,
      model.favoriteCount,
      model.id,
      model.lastActivityDate,
      model.lastEditDate,
      model.lastEditorDisplayName,
      model.lastEditorUserId,
      model.ownerUserId,
      model.parentId,
      model.postTypeId,
      model.score,
      model.tag,
      model.title,
      model.viewCount
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>badaa92199d18989bf92f2ec9d7a0c9c</Hash>
</Codenesium>*/