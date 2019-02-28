import * as Api from '../../api/models';
import UnitMeasureViewModel from  './unitMeasureViewModel';
export default class UnitMeasureMapper {
    
	mapApiResponseToViewModel(dto: Api.UnitMeasureClientResponseModel) : UnitMeasureViewModel 
	{
		let response = new UnitMeasureViewModel();
		response.setProperties(dto.modifiedDate,dto.name,dto.unitMeasureCode);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: UnitMeasureViewModel) : Api.UnitMeasureClientRequestModel
	{
		let response = new Api.UnitMeasureClientRequestModel();
		response.setProperties(model.modifiedDate,model.name,model.unitMeasureCode);
		return response;
	}
};

/*<Codenesium>
    <Hash>6755f97adc7f845a47832897bb38f2dd</Hash>
</Codenesium>*/