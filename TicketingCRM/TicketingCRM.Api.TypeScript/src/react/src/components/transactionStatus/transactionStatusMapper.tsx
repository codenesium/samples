import * as Api from '../../api/models';
import TransactionStatusViewModel from  './transactionStatusViewModel';
export default class TransactionStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.TransactionStatusClientResponseModel) : TransactionStatusViewModel 
	{
		let response = new TransactionStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TransactionStatusViewModel) : Api.TransactionStatusClientRequestModel
	{
		let response = new Api.TransactionStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>0f3ccebde1c72cfcad20214afc48724a</Hash>
</Codenesium>*/