import * as Api from '../../api/models';
import LinkViewModel from './linkViewModel';
import MachineViewModel from '../machine/machineViewModel';
import ChainViewModel from '../chain/chainViewModel';
import LinkStatusViewModel from '../linkStatus/linkStatusViewModel';
export default class LinkMapper {
  mapApiResponseToViewModel(dto: Api.LinkClientResponseModel): LinkViewModel {
    let response = new LinkViewModel();
    response.setProperties(
      dto.assignedMachineId,
      dto.chainId,
      dto.dateCompleted,
      dto.dateStarted,
      dto.dynamicParameter,
      dto.externalId,
      dto.id,
      dto.linkStatusId,
      dto.name,
      dto.order,
      dto.response,
      dto.staticParameter,
      dto.timeoutInSecond
    );

    if (dto.assignedMachineIdNavigation != null) {
      response.assignedMachineIdNavigation = new MachineViewModel();
      response.assignedMachineIdNavigation.setProperties(
        dto.assignedMachineIdNavigation.description,
        dto.assignedMachineIdNavigation.id,
        dto.assignedMachineIdNavigation.jwtKey,
        dto.assignedMachineIdNavigation.lastIpAddress,
        dto.assignedMachineIdNavigation.machineGuid,
        dto.assignedMachineIdNavigation.name
      );
    }
    if (dto.chainIdNavigation != null) {
      response.chainIdNavigation = new ChainViewModel();
      response.chainIdNavigation.setProperties(
        dto.chainIdNavigation.chainStatusId,
        dto.chainIdNavigation.externalId,
        dto.chainIdNavigation.id,
        dto.chainIdNavigation.name,
        dto.chainIdNavigation.teamId
      );
    }
    if (dto.linkStatusIdNavigation != null) {
      response.linkStatusIdNavigation = new LinkStatusViewModel();
      response.linkStatusIdNavigation.setProperties(
        dto.linkStatusIdNavigation.id,
        dto.linkStatusIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: LinkViewModel): Api.LinkClientRequestModel {
    let response = new Api.LinkClientRequestModel();
    response.setProperties(
      model.assignedMachineId,
      model.chainId,
      model.dateCompleted,
      model.dateStarted,
      model.dynamicParameter,
      model.externalId,
      model.id,
      model.linkStatusId,
      model.name,
      model.order,
      model.response,
      model.staticParameter,
      model.timeoutInSecond
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>dce417d3161c43b515fc6b8fd25df9fa</Hash>
</Codenesium>*/