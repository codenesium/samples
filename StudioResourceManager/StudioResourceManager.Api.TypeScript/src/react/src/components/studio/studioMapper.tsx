import * as Api from '../../api/models';
import StudioViewModel from  './studioViewModel';
export default class StudioMapper {
    
	mapApiResponseToViewModel(dto: Api.StudioClientResponseModel) : StudioViewModel 
	{
		let response = new StudioViewModel();
		response.setProperties(dto.address1,dto.address2,dto.city,dto.id,dto.name,dto.province,dto.website,dto.zip);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: StudioViewModel) : Api.StudioClientRequestModel
	{
		let response = new Api.StudioClientRequestModel();
		response.setProperties(model.address1,model.address2,model.city,model.id,model.name,model.province,model.website,model.zip);
		return response;
	}
};

/*<Codenesium>
    <Hash>5a4bf0b645139fe06b75f597f86ae16d</Hash>
</Codenesium>*/