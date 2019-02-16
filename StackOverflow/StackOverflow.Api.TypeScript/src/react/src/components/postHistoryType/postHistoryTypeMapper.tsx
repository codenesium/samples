import * as Api from '../../api/models';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';
export default class PostHistoryTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PostHistoryTypeClientResponseModel
  ): PostHistoryTypeViewModel {
    let response = new PostHistoryTypeViewModel();
    response.setProperties(dto.id, dto.type);

    return response;
  }

  mapViewModelToApiRequest(
    model: PostHistoryTypeViewModel
  ): Api.PostHistoryTypeClientRequestModel {
    let response = new Api.PostHistoryTypeClientRequestModel();
    response.setProperties(model.id, model.type);
    return response;
  }
}


/*<Codenesium>
    <Hash>533694d81d9dbc9862672bcecad01372</Hash>
</Codenesium>*/