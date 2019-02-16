import * as Api from '../../api/models';
import TeamViewModel from './teamViewModel';
import OrganizationViewModel from '../organization/organizationViewModel';
export default class TeamMapper {
  mapApiResponseToViewModel(dto: Api.TeamClientResponseModel): TeamViewModel {
    let response = new TeamViewModel();
    response.setProperties(dto.id, dto.name, dto.organizationId);

    if (dto.organizationIdNavigation != null) {
      response.organizationIdNavigation = new OrganizationViewModel();
      response.organizationIdNavigation.setProperties(
        dto.organizationIdNavigation.id,
        dto.organizationIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: TeamViewModel): Api.TeamClientRequestModel {
    let response = new Api.TeamClientRequestModel();
    response.setProperties(model.id, model.name, model.organizationId);
    return response;
  }
}


/*<Codenesium>
    <Hash>b2b93b054ce9755f33e5c31522466ccb</Hash>
</Codenesium>*/