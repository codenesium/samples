import * as Api from '../../api/models';
import BadgeViewModel from './badgeViewModel';
export default class BadgeMapper {
  mapApiResponseToViewModel(dto: Api.BadgeClientResponseModel): BadgeViewModel {
    let response = new BadgeViewModel();
    response.setProperties(dto.date, dto.id, dto.name, dto.userId);

    return response;
  }

  mapViewModelToApiRequest(model: BadgeViewModel): Api.BadgeClientRequestModel {
    let response = new Api.BadgeClientRequestModel();
    response.setProperties(model.date, model.id, model.name, model.userId);
    return response;
  }
}


/*<Codenesium>
    <Hash>5d942fd6d8f5d7fd79c66d04233c37f0</Hash>
</Codenesium>*/