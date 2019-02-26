import * as Api from '../../api/models';
import AddressViewModel from  './addressViewModel';
	import StateProvinceViewModel from '../stateProvince/stateProvinceViewModel'
	export default class AddressMapper {
    
	mapApiResponseToViewModel(dto: Api.AddressClientResponseModel) : AddressViewModel 
	{
		let response = new AddressViewModel();
		response.setProperties(dto.addressID,dto.addressLine1,dto.addressLine2,dto.city,dto.modifiedDate,dto.postalCode,dto.rowguid,dto.stateProvinceID);
		
						if(dto.stateProvinceIDNavigation != null)
				{
				  response.stateProvinceIDNavigation = new StateProvinceViewModel();
				  response.stateProvinceIDNavigation.setProperties(
				  dto.stateProvinceIDNavigation.countryRegionCode,dto.stateProvinceIDNavigation.isOnlyStateProvinceFlag,dto.stateProvinceIDNavigation.modifiedDate,dto.stateProvinceIDNavigation.name,dto.stateProvinceIDNavigation.rowguid,dto.stateProvinceIDNavigation.stateProvinceCode,dto.stateProvinceIDNavigation.stateProvinceID,dto.stateProvinceIDNavigation.territoryID
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AddressViewModel) : Api.AddressClientRequestModel
	{
		let response = new Api.AddressClientRequestModel();
		response.setProperties(model.addressID,model.addressLine1,model.addressLine2,model.city,model.modifiedDate,model.postalCode,model.rowguid,model.stateProvinceID);
		return response;
	}
};

/*<Codenesium>
    <Hash>8dd62e4d137072f0d1140a4c5a894956</Hash>
</Codenesium>*/