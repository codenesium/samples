import * as Api from '../../api/models';
import EmployeeViewModel from './employeeViewModel';
export default class EmployeeMapper {
  mapApiResponseToViewModel(
    dto: Api.EmployeeClientResponseModel
  ): EmployeeViewModel {
    let response = new EmployeeViewModel();
    response.setProperties(
      dto.firstName,
      dto.id,
      dto.isSalesPerson,
      dto.isShipper,
      dto.lastName
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: EmployeeViewModel
  ): Api.EmployeeClientRequestModel {
    let response = new Api.EmployeeClientRequestModel();
    response.setProperties(
      model.firstName,
      model.id,
      model.isSalesPerson,
      model.isShipper,
      model.lastName
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>6a4c7668ffcdfef40a0dc6216f67bf50</Hash>
</Codenesium>*/