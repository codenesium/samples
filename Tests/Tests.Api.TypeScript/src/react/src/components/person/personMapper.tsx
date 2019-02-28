import * as Api from '../../api/models';
import PersonViewModel from './personViewModel';
export default class PersonMapper {
  mapApiResponseToViewModel(
    dto: Api.PersonClientResponseModel
  ): PersonViewModel {
    let response = new PersonViewModel();
    response.setProperties(dto.personId, dto.personName);

    return response;
  }

  mapViewModelToApiRequest(
    model: PersonViewModel
  ): Api.PersonClientRequestModel {
    let response = new Api.PersonClientRequestModel();
    response.setProperties(model.personId, model.personName);
    return response;
  }
}


/*<Codenesium>
    <Hash>e7173a9c25828b512f2175f8fb223f18</Hash>
</Codenesium>*/