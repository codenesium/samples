import * as Api from '../../api/models';
import PaymentTypeViewModel from  './paymentTypeViewModel';
export default class PaymentTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.PaymentTypeClientResponseModel) : PaymentTypeViewModel 
	{
		let response = new PaymentTypeViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PaymentTypeViewModel) : Api.PaymentTypeClientRequestModel
	{
		let response = new Api.PaymentTypeClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>8975fc82c5b985c3048055354a8386b4</Hash>
</Codenesium>*/