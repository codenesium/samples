import * as Api from '../../api/models';
import DeviceViewModel from  './deviceViewModel';
export default class DeviceMapper {
    
	mapApiResponseToViewModel(dto: Api.DeviceClientResponseModel) : DeviceViewModel 
	{
		let response = new DeviceViewModel();
		response.setProperties(dto.dateOfLastPing,dto.id,dto.isActive,dto.name,dto.publicId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: DeviceViewModel) : Api.DeviceClientRequestModel
	{
		let response = new Api.DeviceClientRequestModel();
		response.setProperties(model.dateOfLastPing,model.id,model.isActive,model.name,model.publicId);
		return response;
	}
};

/*<Codenesium>
    <Hash>f36f0fa7ea42a01ae57e89029d6e6b35</Hash>
</Codenesium>*/