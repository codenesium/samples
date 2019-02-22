import * as Api from '../../api/models';
import PersonTypeViewModel from './personTypeViewModel';
export default class PersonTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PersonTypeClientResponseModel
  ): PersonTypeViewModel {
    let response = new PersonTypeViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PersonTypeViewModel
  ): Api.PersonTypeClientRequestModel {
    let response = new Api.PersonTypeClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>f872853c22d3f8f7b0ee6022950c0027</Hash>
</Codenesium>*/