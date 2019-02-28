import * as Api from '../../api/models';
import EmployeeViewModel from  './employeeViewModel';
export default class EmployeeMapper {
    
	mapApiResponseToViewModel(dto: Api.EmployeeClientResponseModel) : EmployeeViewModel 
	{
		let response = new EmployeeViewModel();
		response.setProperties(dto.birthDate,dto.businessEntityID,dto.currentFlag,dto.gender,dto.hireDate,dto.jobTitle,dto.loginID,dto.maritalStatu,dto.modifiedDate,dto.nationalIDNumber,dto.organizationLevel,dto.rowguid,dto.salariedFlag,dto.sickLeaveHour,dto.vacationHour);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: EmployeeViewModel) : Api.EmployeeClientRequestModel
	{
		let response = new Api.EmployeeClientRequestModel();
		response.setProperties(model.birthDate,model.businessEntityID,model.currentFlag,model.gender,model.hireDate,model.jobTitle,model.loginID,model.maritalStatu,model.modifiedDate,model.nationalIDNumber,model.organizationLevel,model.rowguid,model.salariedFlag,model.sickLeaveHour,model.vacationHour);
		return response;
	}
};

/*<Codenesium>
    <Hash>ffde850607d5c31e75fcbeae4e977c1f</Hash>
</Codenesium>*/