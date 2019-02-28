import * as Api from '../../api/models';
import CallDispositionViewModel from  './callDispositionViewModel';
export default class CallDispositionMapper {
    
	mapApiResponseToViewModel(dto: Api.CallDispositionClientResponseModel) : CallDispositionViewModel 
	{
		let response = new CallDispositionViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CallDispositionViewModel) : Api.CallDispositionClientRequestModel
	{
		let response = new Api.CallDispositionClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>a731692012b93f392471d26767e49bf5</Hash>
</Codenesium>*/