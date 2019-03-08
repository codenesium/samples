import * as Api from '../../api/models';
import UnitViewModel from  './unitViewModel';
export default class UnitMapper {
    
	mapApiResponseToViewModel(dto: Api.UnitClientResponseModel) : UnitViewModel 
	{
		let response = new UnitViewModel();
		response.setProperties(dto.callSign,dto.id);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: UnitViewModel) : Api.UnitClientRequestModel
	{
		let response = new Api.UnitClientRequestModel();
		response.setProperties(model.callSign,model.id);
		return response;
	}
};

/*<Codenesium>
    <Hash>4bd443e9413fc6e0d14111600c166953</Hash>
</Codenesium>*/