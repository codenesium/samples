import * as Api from '../../api/models';
import PostHistoryTypesViewModel from './postHistoryTypesViewModel';
export default class PostHistoryTypesMapper {
  mapApiResponseToViewModel(
    dto: Api.PostHistoryTypesClientResponseModel
  ): PostHistoryTypesViewModel {
    let response = new PostHistoryTypesViewModel();
    response.setProperties(dto.id, dto.rwType);

    return response;
  }

  mapViewModelToApiRequest(
    model: PostHistoryTypesViewModel
  ): Api.PostHistoryTypesClientRequestModel {
    let response = new Api.PostHistoryTypesClientRequestModel();
    response.setProperties(model.id, model.rwType);
    return response;
  }
}


/*<Codenesium>
    <Hash>a5ba98fee7640a2b2dc0c72d0dce1c66</Hash>
</Codenesium>*/