import * as Api from '../../api/models';
import SaleViewModel from './saleViewModel';
import PaymentTypeViewModel from '../paymentType/paymentTypeViewModel';
import PetViewModel from '../pet/petViewModel';
export default class SaleMapper {
  mapApiResponseToViewModel(dto: Api.SaleClientResponseModel): SaleViewModel {
    let response = new SaleViewModel();
    response.setProperties(
      dto.amount,
      dto.firstName,
      dto.id,
      dto.lastName,
      dto.paymentTypeId,
      dto.petId,
      dto.phone
    );

    if (dto.paymentTypeIdNavigation != null) {
      response.paymentTypeIdNavigation = new PaymentTypeViewModel();
      response.paymentTypeIdNavigation.setProperties(
        dto.paymentTypeIdNavigation.id,
        dto.paymentTypeIdNavigation.name
      );
    }
    if (dto.petIdNavigation != null) {
      response.petIdNavigation = new PetViewModel();
      response.petIdNavigation.setProperties(
        dto.petIdNavigation.acquiredDate,
        dto.petIdNavigation.breedId,
        dto.petIdNavigation.description,
        dto.petIdNavigation.id,
        dto.petIdNavigation.penId,
        dto.petIdNavigation.price
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: SaleViewModel): Api.SaleClientRequestModel {
    let response = new Api.SaleClientRequestModel();
    response.setProperties(
      model.amount,
      model.firstName,
      model.id,
      model.lastName,
      model.paymentTypeId,
      model.petId,
      model.phone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2f31492bca1bd76ed73c26b2a82e5ea2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/