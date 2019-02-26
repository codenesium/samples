import * as Api from '../../api/models';
import DepartmentViewModel from  './departmentViewModel';
export default class DepartmentMapper {
    
	mapApiResponseToViewModel(dto: Api.DepartmentClientResponseModel) : DepartmentViewModel 
	{
		let response = new DepartmentViewModel();
		response.setProperties(dto.departmentID,dto.groupName,dto.modifiedDate,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: DepartmentViewModel) : Api.DepartmentClientRequestModel
	{
		let response = new Api.DepartmentClientRequestModel();
		response.setProperties(model.departmentID,model.groupName,model.modifiedDate,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>795b6a2f8d276d406007693ebee9b074</Hash>
</Codenesium>*/