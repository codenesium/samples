import * as Api from '../../api/models';
import PostsViewModel from './postsViewModel';
import UsersViewModel from '../users/usersViewModel';
import PostTypesViewModel from '../postTypes/postTypesViewModel';
export default class PostsMapper {
  mapApiResponseToViewModel(dto: Api.PostsClientResponseModel): PostsViewModel {
    let response = new PostsViewModel();
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
      response.lastEditorUserIdNavigation = new UsersViewModel();
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
      response.ownerUserIdNavigation = new UsersViewModel();
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
      response.parentIdNavigation = new PostsViewModel();
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
      response.postTypeIdNavigation = new PostTypesViewModel();
      response.postTypeIdNavigation.setProperties(
        dto.postTypeIdNavigation.id,
        dto.postTypeIdNavigation.rwType
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: PostsViewModel): Api.PostsClientRequestModel {
    let response = new Api.PostsClientRequestModel();
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
    <Hash>9d1b68328668c55131f57aaff06d88ca</Hash>
</Codenesium>*/