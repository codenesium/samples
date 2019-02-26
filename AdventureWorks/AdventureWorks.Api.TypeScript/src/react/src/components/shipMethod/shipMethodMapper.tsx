import * as Api from '../../api/models';
import ShipMethodViewModel from  './shipMethodViewModel';
export default class ShipMethodMapper {
    
	mapApiResponseToViewModel(dto: Api.ShipMethodClientResponseModel) : ShipMethodViewModel 
	{
		let response = new ShipMethodViewModel();
		response.setProperties(dto.modifiedDate,dto.name,dto.rowguid,dto.shipBase,dto.shipMethodID,dto.shipRate);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ShipMethodViewModel) : Api.ShipMethodClientRequestModel
	{
		let response = new Api.ShipMethodClientRequestModel();
		response.setProperties(model.modifiedDate,model.name,model.rowguid,model.shipBase,model.shipMethodID,model.shipRate);
		return response;
	}
};

/*<Codenesium>
    <Hash>3dfb965717d24cc3d6fc39a4cc16a713</Hash>
</Codenesium>*/