import * as Api from '../../api/models';
import PetViewModel from './petViewModel';
import BreedViewModel from '../breed/breedViewModel';
import PenViewModel from '../pen/penViewModel';
import SpeciesViewModel from '../species/speciesViewModel';
export default class PetMapper {
  mapApiResponseToViewModel(dto: Api.PetClientResponseModel): PetViewModel {
    let response = new PetViewModel();
    response.setProperties(
      dto.acquiredDate,
      dto.breedId,
      dto.description,
      dto.id,
      dto.penId,
      dto.price,
      dto.speciesId
    );

    if (dto.breedIdNavigation != null) {
      response.breedIdNavigation = new BreedViewModel();
      response.breedIdNavigation.setProperties(
        dto.breedIdNavigation.id,
        dto.breedIdNavigation.name
      );
    }
    if (dto.penIdNavigation != null) {
      response.penIdNavigation = new PenViewModel();
      response.penIdNavigation.setProperties(
        dto.penIdNavigation.id,
        dto.penIdNavigation.name
      );
    }
    if (dto.speciesIdNavigation != null) {
      response.speciesIdNavigation = new SpeciesViewModel();
      response.speciesIdNavigation.setProperties(
        dto.speciesIdNavigation.id,
        dto.speciesIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: PetViewModel): Api.PetClientRequestModel {
    let response = new Api.PetClientRequestModel();
    response.setProperties(
      model.acquiredDate,
      model.breedId,
      model.description,
      model.id,
      model.penId,
      model.price,
      model.speciesId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>ad4823770d3e3faf18a93bd4a1d39f82</Hash>
</Codenesium>*/