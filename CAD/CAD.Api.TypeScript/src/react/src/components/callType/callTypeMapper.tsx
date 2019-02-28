import * as Api from '../../api/models';
import CallTypeViewModel from  './callTypeViewModel';
export default class CallTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.CallTypeClientResponseModel) : CallTypeViewModel 
	{
		let response = new CallTypeViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CallTypeViewModel) : Api.CallTypeClientRequestModel
	{
		let response = new Api.CallTypeClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>e576c14c826722272f15fc1b10d550ed</Hash>
</Codenesium>*/