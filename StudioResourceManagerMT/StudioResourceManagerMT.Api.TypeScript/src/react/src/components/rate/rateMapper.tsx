import * as Api from '../../api/models';
import RateViewModel from './rateViewModel';
export default class RateMapper {
  mapApiResponseToViewModel(dto: Api.RateClientResponseModel): RateViewModel {
    let response = new RateViewModel();
    response.setProperties(
      dto.amountPerMinute,
      dto.id,
      dto.teacherId,
      dto.teacherSkillId
    );

    return response;
  }

  mapViewModelToApiRequest(model: RateViewModel): Api.RateClientRequestModel {
    let response = new Api.RateClientRequestModel();
    response.setProperties(
      model.amountPerMinute,
      model.id,
      model.teacherId,
      model.teacherSkillId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>6d163f9dfea5b09f5b2f8a0ab2bfa315</Hash>
</Codenesium>*/