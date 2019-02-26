import * as Api from '../../api/models';
import UnitDispositionViewModel from  './unitDispositionViewModel';
export default class UnitDispositionMapper {
    
	mapApiResponseToViewModel(dto: Api.UnitDispositionClientResponseModel) : UnitDispositionViewModel 
	{
		let response = new UnitDispositionViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: UnitDispositionViewModel) : Api.UnitDispositionClientRequestModel
	{
		let response = new Api.UnitDispositionClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>8574ada525944b5a13b570f3e1804027</Hash>
</Codenesium>*/