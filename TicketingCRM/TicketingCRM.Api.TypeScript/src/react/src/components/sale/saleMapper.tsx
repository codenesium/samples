import * as Api from '../../api/models';
import SaleViewModel from  './saleViewModel';
	import TransactionViewModel from '../transaction/transactionViewModel'
	export default class SaleMapper {
    
	mapApiResponseToViewModel(dto: Api.SaleClientResponseModel) : SaleViewModel 
	{
		let response = new SaleViewModel();
		response.setProperties(dto.id,dto.ipAddress,dto.note,dto.saleDate,dto.transactionId);
		
						if(dto.transactionIdNavigation != null)
				{
				  response.transactionIdNavigation = new TransactionViewModel();
				  response.transactionIdNavigation.setProperties(
				  dto.transactionIdNavigation.amount,dto.transactionIdNavigation.gatewayConfirmationNumber,dto.transactionIdNavigation.id,dto.transactionIdNavigation.transactionStatusId
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SaleViewModel) : Api.SaleClientRequestModel
	{
		let response = new Api.SaleClientRequestModel();
		response.setProperties(model.id,model.ipAddress,model.note,model.saleDate,model.transactionId);
		return response;
	}
};

/*<Codenesium>
    <Hash>f6565df9cbfee3ece41547be6ffa9d22</Hash>
</Codenesium>*/