import * as Api from '../../api/models';
import AWBuildVersionViewModel from  './aWBuildVersionViewModel';
export default class AWBuildVersionMapper {
    
	mapApiResponseToViewModel(dto: Api.AWBuildVersionClientResponseModel) : AWBuildVersionViewModel 
	{
		let response = new AWBuildVersionViewModel();
		response.setProperties(dto.database_Version,dto.modifiedDate,dto.systemInformationID,dto.versionDate);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: AWBuildVersionViewModel) : Api.AWBuildVersionClientRequestModel
	{
		let response = new Api.AWBuildVersionClientRequestModel();
		response.setProperties(model.database_Version,model.modifiedDate,model.systemInformationID,model.versionDate);
		return response;
	}
};

/*<Codenesium>
    <Hash>5e225b5c03616ca57e9df7736a9b52af</Hash>
</Codenesium>*/