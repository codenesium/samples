import * as Api from '../../api/models';
import LinkStatusViewModel from './linkStatusViewModel';
export default class LinkStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.LinkStatusClientResponseModel
  ): LinkStatusViewModel {
    let response = new LinkStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: LinkStatusViewModel
  ): Api.LinkStatusClientRequestModel {
    let response = new Api.LinkStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>dc091b5826fe7ab9250ac96515d53edd</Hash>
</Codenesium>*/