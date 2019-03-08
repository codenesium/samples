import * as Api from '../../api/models';
import LinkTypesViewModel from './linkTypesViewModel';
export default class LinkTypesMapper {
  mapApiResponseToViewModel(
    dto: Api.LinkTypesClientResponseModel
  ): LinkTypesViewModel {
    let response = new LinkTypesViewModel();
    response.setProperties(dto.id, dto.rwType);

    return response;
  }

  mapViewModelToApiRequest(
    model: LinkTypesViewModel
  ): Api.LinkTypesClientRequestModel {
    let response = new Api.LinkTypesClientRequestModel();
    response.setProperties(model.id, model.rwType);
    return response;
  }
}


/*<Codenesium>
    <Hash>8a6e5535083bdb9125828facfa38315d</Hash>
</Codenesium>*/