import * as Api from '../../api/models';
import PetViewModel from './petViewModel';
import BreedViewModel from '../breed/breedViewModel';
export default class PetMapper {
  mapApiResponseToViewModel(dto: Api.PetClientResponseModel): PetViewModel {
    let response = new PetViewModel();
    response.setProperties(
      dto.breedId,
      dto.clientId,
      dto.id,
      dto.name,
      dto.weight
    );

    if (dto.breedIdNavigation != null) {
      response.breedIdNavigation = new BreedViewModel();
      response.breedIdNavigation.setProperties(
        dto.breedIdNavigation.id,
        dto.breedIdNavigation.name,
        dto.breedIdNavigation.speciesId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: PetViewModel): Api.PetClientRequestModel {
    let response = new Api.PetClientRequestModel();
    response.setProperties(
      model.breedId,
      model.clientId,
      model.id,
      model.name,
      model.weight
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>5aca30b8f0ae43480bbb12700f03ef35</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/