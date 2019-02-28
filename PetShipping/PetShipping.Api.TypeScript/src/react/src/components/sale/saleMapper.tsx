import * as Api from '../../api/models';
import SaleViewModel from './saleViewModel';
import PetViewModel from '../pet/petViewModel';
export default class SaleMapper {
  mapApiResponseToViewModel(dto: Api.SaleClientResponseModel): SaleViewModel {
    let response = new SaleViewModel();
    response.setProperties(
      dto.amount,
      dto.cutomerId,
      dto.id,
      dto.note,
      dto.petId,
      dto.saleDate,
      dto.salesPersonId
    );

    if (dto.petIdNavigation != null) {
      response.petIdNavigation = new PetViewModel();
      response.petIdNavigation.setProperties(
        dto.petIdNavigation.breedId,
        dto.petIdNavigation.clientId,
        dto.petIdNavigation.id,
        dto.petIdNavigation.name,
        dto.petIdNavigation.weight
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: SaleViewModel): Api.SaleClientRequestModel {
    let response = new Api.SaleClientRequestModel();
    response.setProperties(
      model.amount,
      model.cutomerId,
      model.id,
      model.note,
      model.petId,
      model.saleDate,
      model.salesPersonId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>8c47edbbcf5beb61e7eda321e8d906b5</Hash>
</Codenesium>*/