import * as Api from '../../api/models';
import ClaspViewModel from './claspViewModel';
import ChainViewModel from '../chain/chainViewModel';
export default class ClaspMapper {
  mapApiResponseToViewModel(dto: Api.ClaspClientResponseModel): ClaspViewModel {
    let response = new ClaspViewModel();
    response.setProperties(dto.id, dto.nextChainId, dto.previousChainId);

    if (dto.nextChainIdNavigation != null) {
      response.nextChainIdNavigation = new ChainViewModel();
      response.nextChainIdNavigation.setProperties(
        dto.nextChainIdNavigation.chainStatusId,
        dto.nextChainIdNavigation.externalId,
        dto.nextChainIdNavigation.id,
        dto.nextChainIdNavigation.name,
        dto.nextChainIdNavigation.teamId
      );
    }
    if (dto.previousChainIdNavigation != null) {
      response.previousChainIdNavigation = new ChainViewModel();
      response.previousChainIdNavigation.setProperties(
        dto.previousChainIdNavigation.chainStatusId,
        dto.previousChainIdNavigation.externalId,
        dto.previousChainIdNavigation.id,
        dto.previousChainIdNavigation.name,
        dto.previousChainIdNavigation.teamId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: ClaspViewModel): Api.ClaspClientRequestModel {
    let response = new Api.ClaspClientRequestModel();
    response.setProperties(model.id, model.nextChainId, model.previousChainId);
    return response;
  }
}


/*<Codenesium>
    <Hash>da0a26615c19913bb6637d0d78b95280</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/