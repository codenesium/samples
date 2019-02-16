import * as Api from '../api/models';
import RateViewModel from '../viewmodels/rateViewModel';

export default class RateMapper {
  mapApiResponseToViewModel(dto: Api.RateClientResponseModel): RateViewModel {
    let response = new RateViewModel();
    response.setProperties(
      dto.amountPerMinute,
      dto.id,
      dto.isDeleted,
      dto.teacherId,
      dto.teacherSkillId,
      dto.tenantId
    );
    return response;
  }

  mapViewModelToApiRequest(model: RateViewModel): Api.RateClientRequestModel {
    let response = new Api.RateClientRequestModel();
    response.setProperties(
      model.amountPerMinute,
      model.id,
      model.isDeleted,
      model.teacherId,
      model.teacherSkillId,
      model.tenantId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>8af7a9d0e65f578c00f4d9b7289ebdb9</Hash>
</Codenesium>*/