import * as Api from '../../api/models';
import LinkLogViewModel from './linkLogViewModel';
import LinkViewModel from '../link/linkViewModel';
export default class LinkLogMapper {
  mapApiResponseToViewModel(
    dto: Api.LinkLogClientResponseModel
  ): LinkLogViewModel {
    let response = new LinkLogViewModel();
    response.setProperties(dto.dateEntered, dto.id, dto.linkId, dto.log);

    if (dto.linkIdNavigation != null) {
      response.linkIdNavigation = new LinkViewModel();
      response.linkIdNavigation.setProperties(
        dto.linkIdNavigation.assignedMachineId,
        dto.linkIdNavigation.chainId,
        dto.linkIdNavigation.dateCompleted,
        dto.linkIdNavigation.dateStarted,
        dto.linkIdNavigation.dynamicParameter,
        dto.linkIdNavigation.externalId,
        dto.linkIdNavigation.id,
        dto.linkIdNavigation.linkStatusId,
        dto.linkIdNavigation.name,
        dto.linkIdNavigation.order,
        dto.linkIdNavigation.response,
        dto.linkIdNavigation.staticParameter,
        dto.linkIdNavigation.timeoutInSecond
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: LinkLogViewModel
  ): Api.LinkLogClientRequestModel {
    let response = new Api.LinkLogClientRequestModel();
    response.setProperties(
      model.dateEntered,
      model.id,
      model.linkId,
      model.log
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>929ab1503bc994db4daf59340330c776</Hash>
</Codenesium>*/