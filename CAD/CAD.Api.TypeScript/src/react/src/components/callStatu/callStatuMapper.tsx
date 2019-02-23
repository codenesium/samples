import * as Api from '../../api/models';
import CallStatuViewModel from  './callStatuViewModel';
export default class CallStatuMapper {
    
	mapApiResponseToViewModel(dto: Api.CallStatuClientResponseModel) : CallStatuViewModel 
	{
		let response = new CallStatuViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CallStatuViewModel) : Api.CallStatuClientRequestModel
	{
		let response = new Api.CallStatuClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>94b9bf80ec16ccd112c0cacb076f2d66</Hash>
</Codenesium>*/