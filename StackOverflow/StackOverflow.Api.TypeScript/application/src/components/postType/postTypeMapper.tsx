import * as Api from '../../api/models';
import PostTypeViewModel from  './postTypeViewModel';
export default class PostTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.PostTypeClientResponseModel) : PostTypeViewModel 
	{
		let response = new PostTypeViewModel();
		response.setProperties(dto.id,dto.type);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PostTypeViewModel) : Api.PostTypeClientRequestModel
	{
		let response = new Api.PostTypeClientRequestModel();
		response.setProperties(model.id,model.type);
		return response;
	}
};

/*<Codenesium>
    <Hash>f2595900801698f9ee21fa4ac778a995</Hash>
</Codenesium>*/