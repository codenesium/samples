import * as Api from '../../api/models';
import SpeciesViewModel from './speciesViewModel';
export default class SpeciesMapper {
  mapApiResponseToViewModel(
    dto: Api.SpeciesClientResponseModel
  ): SpeciesViewModel {
    let response = new SpeciesViewModel();
    response.setProperties(dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: SpeciesViewModel
  ): Api.SpeciesClientRequestModel {
    let response = new Api.SpeciesClientRequestModel();
    response.setProperties(model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>8005e2c6cd1c2ed0be792c2150c98cf0</Hash>
</Codenesium>*/