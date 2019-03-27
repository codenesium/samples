import * as Api from '../../api/models';
import MachineRefTeamViewModel from './machineRefTeamViewModel';
import MachineViewModel from '../machine/machineViewModel';
import TeamViewModel from '../team/teamViewModel';
export default class MachineRefTeamMapper {
  mapApiResponseToViewModel(
    dto: Api.MachineRefTeamClientResponseModel
  ): MachineRefTeamViewModel {
    let response = new MachineRefTeamViewModel();
    response.setProperties(dto.id, dto.machineId, dto.teamId);

    if (dto.machineIdNavigation != null) {
      response.machineIdNavigation = new MachineViewModel();
      response.machineIdNavigation.setProperties(
        dto.machineIdNavigation.description,
        dto.machineIdNavigation.id,
        dto.machineIdNavigation.jwtKey,
        dto.machineIdNavigation.lastIpAddress,
        dto.machineIdNavigation.machineGuid,
        dto.machineIdNavigation.name
      );
    }
    if (dto.teamIdNavigation != null) {
      response.teamIdNavigation = new TeamViewModel();
      response.teamIdNavigation.setProperties(
        dto.teamIdNavigation.id,
        dto.teamIdNavigation.name,
        dto.teamIdNavigation.organizationId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: MachineRefTeamViewModel
  ): Api.MachineRefTeamClientRequestModel {
    let response = new Api.MachineRefTeamClientRequestModel();
    response.setProperties(model.id, model.machineId, model.teamId);
    return response;
  }
}


/*<Codenesium>
    <Hash>fbd07e16cd1a7a2b3de8cc359b3a3700</Hash>
</Codenesium>*/