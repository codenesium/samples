import * as Api from '../../api/models';
import PostTypeViewModel from  './postTypeViewModel';
export default class PostTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.PostTypeClientResponseModel) : PostTypeViewModel 
	{
		let response = new PostTypeViewModel();
		response.setProperties(dto.id,dto.rwType);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostTypeViewModel) : Api.PostTypeClientRequestModel
	{
		let response = new Api.PostTypeClientRequestModel();
		response.setProperties(model.id,model.rwType);
		return response;
	}
};

/*<Codenesium>
    <Hash>45eb195d45d35fde7af75d5d3033ded3</Hash>
</Codenesium>*/