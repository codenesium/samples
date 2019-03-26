import * as Api from '../../api/models';
import LinkTypeViewModel from './linkTypeViewModel';
export default class LinkTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.LinkTypeClientResponseModel
  ): LinkTypeViewModel {
    let response = new LinkTypeViewModel();
    response.setProperties(dto.id, dto.rwType);

    return response;
  }

  mapViewModelToApiRequest(
    model: LinkTypeViewModel
  ): Api.LinkTypeClientRequestModel {
    let response = new Api.LinkTypeClientRequestModel();
    response.setProperties(model.id, model.rwType);
    return response;
  }
}


/*<Codenesium>
    <Hash>176f25ccf73f3fb79ea4f474849585cb</Hash>
</Codenesium>*/