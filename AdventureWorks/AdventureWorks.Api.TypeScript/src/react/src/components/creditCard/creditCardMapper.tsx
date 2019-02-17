import * as Api from '../../api/models';
import CreditCardViewModel from  './creditCardViewModel';
export default class CreditCardMapper {
    
	mapApiResponseToViewModel(dto: Api.CreditCardClientResponseModel) : CreditCardViewModel 
	{
		let response = new CreditCardViewModel();
		response.setProperties(dto.cardNumber,dto.cardType,dto.creditCardID,dto.expMonth,dto.expYear,dto.modifiedDate);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CreditCardViewModel) : Api.CreditCardClientRequestModel
	{
		let response = new Api.CreditCardClientRequestModel();
		response.setProperties(model.cardNumber,model.cardType,model.creditCardID,model.expMonth,model.expYear,model.modifiedDate);
		return response;
	}
};

/*<Codenesium>
    <Hash>0b5df34006c33ad9ba16a6fa52453d9f</Hash>
</Codenesium>*/