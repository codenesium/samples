import * as Api from '../../api/models';
import TagsViewModel from './tagsViewModel';
import PostsViewModel from '../posts/postsViewModel';
export default class TagsMapper {
  mapApiResponseToViewModel(dto: Api.TagsClientResponseModel): TagsViewModel {
    let response = new TagsViewModel();
    response.setProperties(
      dto.count,
      dto.excerptPostId,
      dto.id,
      dto.tagName,
      dto.wikiPostId
    );

    if (dto.excerptPostIdNavigation != null) {
      response.excerptPostIdNavigation = new PostsViewModel();
      response.excerptPostIdNavigation.setProperties(
        dto.excerptPostIdNavigation.acceptedAnswerId,
        dto.excerptPostIdNavigation.answerCount,
        dto.excerptPostIdNavigation.body,
        dto.excerptPostIdNavigation.closedDate,
        dto.excerptPostIdNavigation.commentCount,
        dto.excerptPostIdNavigation.communityOwnedDate,
        dto.excerptPostIdNavigation.creationDate,
        dto.excerptPostIdNavigation.favoriteCount,
        dto.excerptPostIdNavigation.id,
        dto.excerptPostIdNavigation.lastActivityDate,
        dto.excerptPostIdNavigation.lastEditDate,
        dto.excerptPostIdNavigation.lastEditorDisplayName,
        dto.excerptPostIdNavigation.lastEditorUserId,
        dto.excerptPostIdNavigation.ownerUserId,
        dto.excerptPostIdNavigation.parentId,
        dto.excerptPostIdNavigation.postTypeId,
        dto.excerptPostIdNavigation.score,
        dto.excerptPostIdNavigation.tag,
        dto.excerptPostIdNavigation.title,
        dto.excerptPostIdNavigation.viewCount
      );
    }
    if (dto.wikiPostIdNavigation != null) {
      response.wikiPostIdNavigation = new PostsViewModel();
      response.wikiPostIdNavigation.setProperties(
        dto.wikiPostIdNavigation.acceptedAnswerId,
        dto.wikiPostIdNavigation.answerCount,
        dto.wikiPostIdNavigation.body,
        dto.wikiPostIdNavigation.closedDate,
        dto.wikiPostIdNavigation.commentCount,
        dto.wikiPostIdNavigation.communityOwnedDate,
        dto.wikiPostIdNavigation.creationDate,
        dto.wikiPostIdNavigation.favoriteCount,
        dto.wikiPostIdNavigation.id,
        dto.wikiPostIdNavigation.lastActivityDate,
        dto.wikiPostIdNavigation.lastEditDate,
        dto.wikiPostIdNavigation.lastEditorDisplayName,
        dto.wikiPostIdNavigation.lastEditorUserId,
        dto.wikiPostIdNavigation.ownerUserId,
        dto.wikiPostIdNavigation.parentId,
        dto.wikiPostIdNavigation.postTypeId,
        dto.wikiPostIdNavigation.score,
        dto.wikiPostIdNavigation.tag,
        dto.wikiPostIdNavigation.title,
        dto.wikiPostIdNavigation.viewCount
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: TagsViewModel): Api.TagsClientRequestModel {
    let response = new Api.TagsClientRequestModel();
    response.setProperties(
      model.count,
      model.excerptPostId,
      model.id,
      model.tagName,
      model.wikiPostId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>04204df15ed784cf70b0475b4a72b34a</Hash>
</Codenesium>*/