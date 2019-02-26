import * as Api from '../../api/models';
import ScrapReasonViewModel from  './scrapReasonViewModel';
export default class ScrapReasonMapper {
    
	mapApiResponseToViewModel(dto: Api.ScrapReasonClientResponseModel) : ScrapReasonViewModel 
	{
		let response = new ScrapReasonViewModel();
		response.setProperties(dto.modifiedDate,dto.name,dto.scrapReasonID);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ScrapReasonViewModel) : Api.ScrapReasonClientRequestModel
	{
		let response = new Api.ScrapReasonClientRequestModel();
		response.setProperties(model.modifiedDate,model.name,model.scrapReasonID);
		return response;
	}
};

/*<Codenesium>
    <Hash>846fa25d0ce6d5af93de62716c4e7253</Hash>
</Codenesium>*/