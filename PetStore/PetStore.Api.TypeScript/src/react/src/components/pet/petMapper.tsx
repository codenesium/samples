import * as Api from '../../api/models';
import PetViewModel from './petViewModel';
import BreedViewModel from '../breed/breedViewModel';
import PenViewModel from '../pen/penViewModel';
export default class PetMapper {
  mapApiResponseToViewModel(dto: Api.PetClientResponseModel): PetViewModel {
    let response = new PetViewModel();
    response.setProperties(
      dto.acquiredDate,
      dto.breedId,
      dto.description,
      dto.penId,
      dto.price
    );

    if (dto.breedIdNavigation != null) {
      response.breedIdNavigation = new BreedViewModel();
      response.breedIdNavigation.setProperties(
        dto.breedIdNavigation.name,
        dto.breedIdNavigation.speciesId
      );
    }
    if (dto.penIdNavigation != null) {
      response.penIdNavigation = new PenViewModel();
      response.penIdNavigation.setProperties(dto.penIdNavigation.name);
    }

    return response;
  }

  mapViewModelToApiRequest(model: PetViewModel): Api.PetClientRequestModel {
    let response = new Api.PetClientRequestModel();
    response.setProperties(
      model.acquiredDate,
      model.breedId,
      model.description,
      model.penId,
      model.price
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>063db8dd59d739d376699ce39151ebcb</Hash>
</Codenesium>*/