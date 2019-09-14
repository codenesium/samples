import * as Api from '../../api/models';
import ChainViewModel from './chainViewModel';
import ChainStatusViewModel from '../chainStatus/chainStatusViewModel';
import TeamViewModel from '../team/teamViewModel';
export default class ChainMapper {
  mapApiResponseToViewModel(dto: Api.ChainClientResponseModel): ChainViewModel {
    let response = new ChainViewModel();
    response.setProperties(
      dto.chainStatusId,
      dto.externalId,
      dto.id,
      dto.name,
      dto.teamId
    );

    if (dto.chainStatusIdNavigation != null) {
      response.chainStatusIdNavigation = new ChainStatusViewModel();
      response.chainStatusIdNavigation.setProperties(
        dto.chainStatusIdNavigation.id,
        dto.chainStatusIdNavigation.name
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

  mapViewModelToApiRequest(model: ChainViewModel): Api.ChainClientRequestModel {
    let response = new Api.ChainClientRequestModel();
    response.setProperties(
      model.chainStatusId,
      model.externalId,
      model.id,
      model.name,
      model.teamId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>6299c70097ee3eea4dbd540e76861571</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/