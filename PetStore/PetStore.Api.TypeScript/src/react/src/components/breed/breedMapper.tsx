import * as Api from '../../api/models';
import BreedViewModel from './breedViewModel';
export default class BreedMapper {
  mapApiResponseToViewModel(dto: Api.BreedClientResponseModel): BreedViewModel {
    let response = new BreedViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(model: BreedViewModel): Api.BreedClientRequestModel {
    let response = new Api.BreedClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>f3f7a19ac7c6943f6a2ff2266f1f0fde</Hash>
</Codenesium>*/