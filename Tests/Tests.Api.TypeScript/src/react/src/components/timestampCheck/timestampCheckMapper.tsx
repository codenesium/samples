import * as Api from '../../api/models';
import TimestampCheckViewModel from  './timestampCheckViewModel';
export default class TimestampCheckMapper {
    
	mapApiResponseToViewModel(dto: Api.TimestampCheckClientResponseModel) : TimestampCheckViewModel 
	{
		let response = new TimestampCheckViewModel();
		response.setProperties(dto.id,dto.name,dto.timestamp);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TimestampCheckViewModel) : Api.TimestampCheckClientRequestModel
	{
		let response = new Api.TimestampCheckClientRequestModel();
		response.setProperties(model.id,model.name,model.timestamp);
		return response;
	}
};

/*<Codenesium>
    <Hash>80686b1352737a6bfb95188b59c1ed41</Hash>
</Codenesium>*/