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
      dto.dynamicParameters,
      dto.externalId,
      dto.id,
      dto.linkStatusId,
      dto.name,
      dto.order,
      dto.response,
      dto.staticParameters,
      dto.timeoutInSeconds
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
      model.dynamicParameters,
      model.externalId,
      model.id,
      model.linkStatusId,
      model.name,
      model.order,
      model.response,
      model.staticParameters,
      model.timeoutInSeconds
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>957db97cc901ca1f9a86f0130cf611dd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/