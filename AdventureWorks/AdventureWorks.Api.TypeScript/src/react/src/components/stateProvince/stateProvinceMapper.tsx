import * as Api from '../../api/models';
import StateProvinceViewModel from  './stateProvinceViewModel';
export default class StateProvinceMapper {
    
	mapApiResponseToViewModel(dto: Api.StateProvinceClientResponseModel) : StateProvinceViewModel 
	{
		let response = new StateProvinceViewModel();
		response.setProperties(dto.countryRegionCode,dto.isOnlyStateProvinceFlag,dto.modifiedDate,dto.name,dto.rowguid,dto.stateProvinceCode,dto.stateProvinceID,dto.territoryID);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: StateProvinceViewModel) : Api.StateProvinceClientRequestModel
	{
		let response = new Api.StateProvinceClientRequestModel();
		response.setProperties(model.countryRegionCode,model.isOnlyStateProvinceFlag,model.modifiedDate,model.name,model.rowguid,model.stateProvinceCode,model.stateProvinceID,model.territoryID);
		return response;
	}
};

/*<Codenesium>
    <Hash>128ddebd9f1042f66dffd3f9788535c8</Hash>
</Codenesium>*/