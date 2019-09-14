import * as Api from '../../api/models';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';
export default class PostHistoryTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PostHistoryTypeClientResponseModel
  ): PostHistoryTypeViewModel {
    let response = new PostHistoryTypeViewModel();
    response.setProperties(dto.id, dto.rwType);

    return response;
  }

  mapViewModelToApiRequest(
    model: PostHistoryTypeViewModel
  ): Api.PostHistoryTypeClientRequestModel {
    let response = new Api.PostHistoryTypeClientRequestModel();
    response.setProperties(model.id, model.rwType);
    return response;
  }
}


/*<Codenesium>
    <Hash>684acde4f7bf1b50390f658d966631cd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/