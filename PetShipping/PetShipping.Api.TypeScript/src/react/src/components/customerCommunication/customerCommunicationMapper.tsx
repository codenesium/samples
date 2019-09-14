import * as Api from '../../api/models';
import CustomerCommunicationViewModel from './customerCommunicationViewModel';
import CustomerViewModel from '../customer/customerViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';
export default class CustomerCommunicationMapper {
  mapApiResponseToViewModel(
    dto: Api.CustomerCommunicationClientResponseModel
  ): CustomerCommunicationViewModel {
    let response = new CustomerCommunicationViewModel();
    response.setProperties(
      dto.customerId,
      dto.dateCreated,
      dto.employeeId,
      dto.id,
      dto.notes
    );

    if (dto.customerIdNavigation != null) {
      response.customerIdNavigation = new CustomerViewModel();
      response.customerIdNavigation.setProperties(
        dto.customerIdNavigation.email,
        dto.customerIdNavigation.firstName,
        dto.customerIdNavigation.id,
        dto.customerIdNavigation.lastName,
        dto.customerIdNavigation.notes,
        dto.customerIdNavigation.phone
      );
    }
    if (dto.employeeIdNavigation != null) {
      response.employeeIdNavigation = new EmployeeViewModel();
      response.employeeIdNavigation.setProperties(
        dto.employeeIdNavigation.firstName,
        dto.employeeIdNavigation.id,
        dto.employeeIdNavigation.isSalesPerson,
        dto.employeeIdNavigation.isShipper,
        dto.employeeIdNavigation.lastName
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: CustomerCommunicationViewModel
  ): Api.CustomerCommunicationClientRequestModel {
    let response = new Api.CustomerCommunicationClientRequestModel();
    response.setProperties(
      model.customerId,
      model.dateCreated,
      model.employeeId,
      model.id,
      model.notes
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>47b2281fded8ca90889efbb88e31ef36</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/