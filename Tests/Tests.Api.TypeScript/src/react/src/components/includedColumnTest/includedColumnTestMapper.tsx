import * as Api from '../../api/models';
import IncludedColumnTestViewModel from  './includedColumnTestViewModel';
export default class IncludedColumnTestMapper {
    
	mapApiResponseToViewModel(dto: Api.IncludedColumnTestClientResponseModel) : IncludedColumnTestViewModel 
	{
		let response = new IncludedColumnTestViewModel();
		response.setProperties(dto.id,dto.name,dto.name2);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: IncludedColumnTestViewModel) : Api.IncludedColumnTestClientRequestModel
	{
		let response = new Api.IncludedColumnTestClientRequestModel();
		response.setProperties(model.id,model.name,model.name2);
		return response;
	}
};

/*<Codenesium>
    <Hash>84aa81f789f29c689a148de6d3d566de</Hash>
</Codenesium>*/