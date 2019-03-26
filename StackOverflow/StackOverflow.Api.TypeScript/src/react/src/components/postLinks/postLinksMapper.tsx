import * as Api from '../../api/models';
import PostLinksViewModel from './postLinksViewModel';
import LinkTypesViewModel from '../linkTypes/linkTypesViewModel';
import PostsViewModel from '../posts/postsViewModel';
export default class PostLinksMapper {
  mapApiResponseToViewModel(
    dto: Api.PostLinksClientResponseModel
  ): PostLinksViewModel {
    let response = new PostLinksViewModel();
    response.setProperties(
      dto.creationDate,
      dto.id,
      dto.linkTypeId,
      dto.postId,
      dto.relatedPostId
    );

    if (dto.linkTypeIdNavigation != null) {
      response.linkTypeIdNavigation = new LinkTypesViewModel();
      response.linkTypeIdNavigation.setProperties(
        dto.linkTypeIdNavigation.id,
        dto.linkTypeIdNavigation.rwType
      );
    }
    if (dto.postIdNavigation != null) {
      response.postIdNavigation = new PostsViewModel();
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
    if (dto.relatedPostIdNavigation != null) {
      response.relatedPostIdNavigation = new PostsViewModel();
      response.relatedPostIdNavigation.setProperties(
        dto.relatedPostIdNavigation.acceptedAnswerId,
        dto.relatedPostIdNavigation.answerCount,
        dto.relatedPostIdNavigation.body,
        dto.relatedPostIdNavigation.closedDate,
        dto.relatedPostIdNavigation.commentCount,
        dto.relatedPostIdNavigation.communityOwnedDate,
        dto.relatedPostIdNavigation.creationDate,
        dto.relatedPostIdNavigation.favoriteCount,
        dto.relatedPostIdNavigation.id,
        dto.relatedPostIdNavigation.lastActivityDate,
        dto.relatedPostIdNavigation.lastEditDate,
        dto.relatedPostIdNavigation.lastEditorDisplayName,
        dto.relatedPostIdNavigation.lastEditorUserId,
        dto.relatedPostIdNavigation.ownerUserId,
        dto.relatedPostIdNavigation.parentId,
        dto.relatedPostIdNavigation.postTypeId,
        dto.relatedPostIdNavigation.score,
        dto.relatedPostIdNavigation.tag,
        dto.relatedPostIdNavigation.title,
        dto.relatedPostIdNavigation.viewCount
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PostLinksViewModel
  ): Api.PostLinksClientRequestModel {
    let response = new Api.PostLinksClientRequestModel();
    response.setProperties(
      model.creationDate,
      model.id,
      model.linkTypeId,
      model.postId,
      model.relatedPostId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>3c429c83ffbc58555c93b40d2c3a4486</Hash>
</Codenesium>*/