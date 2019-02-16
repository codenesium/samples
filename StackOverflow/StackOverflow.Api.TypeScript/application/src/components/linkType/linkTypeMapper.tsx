import * as Api from '../../api/models';
import LinkTypeViewModel from './linkTypeViewModel';
export default class LinkTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.LinkTypeClientResponseModel
  ): LinkTypeViewModel {
    let response = new LinkTypeViewModel();
    response.setProperties(dto.id, dto.type);

    return response;
  }

  mapViewModelToApiRequest(
    model: LinkTypeViewModel
  ): Api.LinkTypeClientRequestModel {
    let response = new Api.LinkTypeClientRequestModel();
    response.setProperties(model.id, model.type);
    return response;
  }
}


/*<Codenesium>
    <Hash>e9abd54fdb6141ee2424649f4ce5aba6</Hash>
</Codenesium>*/