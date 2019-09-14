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
        dto.linkIdNavigation.dynamicParameters,
        dto.linkIdNavigation.externalId,
        dto.linkIdNavigation.id,
        dto.linkIdNavigation.linkStatusId,
        dto.linkIdNavigation.name,
        dto.linkIdNavigation.order,
        dto.linkIdNavigation.response,
        dto.linkIdNavigation.staticParameters,
        dto.linkIdNavigation.timeoutInSeconds
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
    <Hash>e9706aa00ffcecc55df509461a2d6eb5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/