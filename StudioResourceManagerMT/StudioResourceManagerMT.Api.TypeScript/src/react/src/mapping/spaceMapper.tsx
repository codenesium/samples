import * as Api from '../api/models';
import SpaceViewModel from  '../viewmodels/spaceViewModel';

export default class SpaceMapper {
    
	mapApiResponseToViewModel(dto: Api.SpaceClientResponseModel) : SpaceViewModel 
	{
		let response = new SpaceViewModel();
		response.setProperties(dto.description,dto.id,dto.isDeleted,dto.name,dto.tenantId);
		return response;
	}

	mapViewModelToApiRequest(model: SpaceViewModel) : Api.SpaceClientRequestModel
	{
		let response = new Api.SpaceClientRequestModel();
		response.setProperties(model.description,model.id,model.isDeleted,model.name,model.tenantId);
		return response;
	}
};

/*<Codenesium>
    <Hash>8afccd1a92db2df97ec6d1af327fa9e2</Hash>
</Codenesium>*/