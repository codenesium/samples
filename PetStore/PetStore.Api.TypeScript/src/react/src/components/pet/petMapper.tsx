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
      dto.id,
      dto.penId,
      dto.price
    );

    if (dto.breedIdNavigation != null) {
      response.breedIdNavigation = new BreedViewModel();
      response.breedIdNavigation.setProperties(
        dto.breedIdNavigation.id,
        dto.breedIdNavigation.name,
        dto.breedIdNavigation.speciesId
      );
    }
    if (dto.penIdNavigation != null) {
      response.penIdNavigation = new PenViewModel();
      response.penIdNavigation.setProperties(
        dto.penIdNavigation.id,
        dto.penIdNavigation.name
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
      model.price
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>8a2f7af4fa42bfe89cfe8fcedecfe642</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/