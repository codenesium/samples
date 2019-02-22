import * as Api from '../../api/models';
import BucketViewModel from  './bucketViewModel';
export default class BucketMapper {
    
	mapApiResponseToViewModel(dto: Api.BucketClientResponseModel) : BucketViewModel 
	{
		let response = new BucketViewModel();
		response.setProperties(dto.externalId,dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: BucketViewModel) : Api.BucketClientRequestModel
	{
		let response = new Api.BucketClientRequestModel();
		response.setProperties(model.externalId,model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>bf3c3423028f13ca54bbd7876f925cd3</Hash>
</Codenesium>*/