import * as Api from '../../api/models';
import StateProvinceViewModel from  './stateProvinceViewModel';
	import CountryRegionViewModel from '../countryRegion/countryRegionViewModel'
	export default class StateProvinceMapper {
    
	mapApiResponseToViewModel(dto: Api.StateProvinceClientResponseModel) : StateProvinceViewModel 
	{
		let response = new StateProvinceViewModel();
		response.setProperties(dto.countryRegionCode,dto.isOnlyStateProvinceFlag,dto.modifiedDate,dto.name,dto.rowguid,dto.stateProvinceCode,dto.stateProvinceID,dto.territoryID);
		
						if(dto.countryRegionCodeNavigation != null)
				{
				  response.countryRegionCodeNavigation = new CountryRegionViewModel();
				  response.countryRegionCodeNavigation.setProperties(
				  dto.countryRegionCodeNavigation.countryRegionCode,dto.countryRegionCodeNavigation.modifiedDate,dto.countryRegionCodeNavigation.name
				  );
				}
					

		
		
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
    <Hash>6d79ce4fde72c7b1289b84a856110c5b</Hash>
</Codenesium>*/