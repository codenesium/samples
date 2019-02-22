import * as Api from '../../api/models';
import EmployeeViewModel from  './employeeViewModel';
export default class EmployeeMapper {
    
	mapApiResponseToViewModel(dto: Api.EmployeeClientResponseModel) : EmployeeViewModel 
	{
		let response = new EmployeeViewModel();
		response.setProperties(dto.firstName,dto.id,dto.isSalesPerson,dto.isShipper,dto.lastName);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: EmployeeViewModel) : Api.EmployeeClientRequestModel
	{
		let response = new Api.EmployeeClientRequestModel();
		response.setProperties(model.firstName,model.id,model.isSalesPerson,model.isShipper,model.lastName);
		return response;
	}
};

/*<Codenesium>
    <Hash>0a07ca616051693b01edb445757a8981</Hash>
</Codenesium>*/