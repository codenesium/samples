import * as Api from '../../api/models';
import SaleViewModel from  './saleViewModel';
	import PaymentTypeViewModel from '../paymentType/paymentTypeViewModel'
		import PetViewModel from '../pet/petViewModel'
	export default class SaleMapper {
    
	mapApiResponseToViewModel(dto: Api.SaleClientResponseModel) : SaleViewModel 
	{
		let response = new SaleViewModel();
		response.setProperties(dto.amount,dto.firstName,dto.id,dto.lastName,dto.paymentTypeId,dto.petId,dto.phone);
		
						if(dto.paymentTypeIdNavigation != null)
				{
				  response.paymentTypeIdNavigation = new PaymentTypeViewModel();
				  response.paymentTypeIdNavigation.setProperties(
				  dto.paymentTypeIdNavigation.id,dto.paymentTypeIdNavigation.name
				  );
				}
							if(dto.petIdNavigation != null)
				{
				  response.petIdNavigation = new PetViewModel();
				  response.petIdNavigation.setProperties(
				  dto.petIdNavigation.acquiredDate,dto.petIdNavigation.breedId,dto.petIdNavigation.description,dto.petIdNavigation.id,dto.petIdNavigation.penId,dto.petIdNavigation.price,dto.petIdNavigation.speciesId
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SaleViewModel) : Api.SaleClientRequestModel
	{
		let response = new Api.SaleClientRequestModel();
		response.setProperties(model.amount,model.firstName,model.id,model.lastName,model.paymentTypeId,model.petId,model.phone);
		return response;
	}
};

/*<Codenesium>
    <Hash>6803056344c61b0f0ca853c17ce75230</Hash>
</Codenesium>*/