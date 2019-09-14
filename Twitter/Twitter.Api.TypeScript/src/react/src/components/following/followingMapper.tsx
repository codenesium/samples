import * as Api from '../../api/models';
import FollowingViewModel from './followingViewModel';
export default class FollowingMapper {
  mapApiResponseToViewModel(
    dto: Api.FollowingClientResponseModel
  ): FollowingViewModel {
    let response = new FollowingViewModel();
    response.setProperties(dto.dateFollowed, dto.muted, dto.userId);

    return response;
  }

  mapViewModelToApiRequest(
    model: FollowingViewModel
  ): Api.FollowingClientRequestModel {
    let response = new Api.FollowingClientRequestModel();
    response.setProperties(model.dateFollowed, model.muted, model.userId);
    return response;
  }
}


/*<Codenesium>
    <Hash>606e2c13755179c6d05a613704b98498</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/