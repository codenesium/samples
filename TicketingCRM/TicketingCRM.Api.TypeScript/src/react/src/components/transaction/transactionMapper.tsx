import * as Api from '../../api/models';
import TransactionViewModel from  './transactionViewModel';
	import TransactionStatusViewModel from '../transactionStatus/transactionStatusViewModel'
	export default class TransactionMapper {
    
	mapApiResponseToViewModel(dto: Api.TransactionClientResponseModel) : TransactionViewModel 
	{
		let response = new TransactionViewModel();
		response.setProperties(dto.amount,dto.gatewayConfirmationNumber,dto.id,dto.transactionStatusId);
		
						if(dto.transactionStatusIdNavigation != null)
				{
				  response.transactionStatusIdNavigation = new TransactionStatusViewModel();
				  response.transactionStatusIdNavigation.setProperties(
				  dto.transactionStatusIdNavigation.id,dto.transactionStatusIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TransactionViewModel) : Api.TransactionClientRequestModel
	{
		let response = new Api.TransactionClientRequestModel();
		response.setProperties(model.amount,model.gatewayConfirmationNumber,model.id,model.transactionStatusId);
		return response;
	}
};

/*<Codenesium>
    <Hash>06395378ebe92c3b65a1100243ba17ea</Hash>
</Codenesium>*/