import * as Api from '../../api/models';
import PipelineStepViewModel from './pipelineStepViewModel';
import PipelineStepStatusViewModel from '../pipelineStepStatus/pipelineStepStatusViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';
export default class PipelineStepMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStepClientResponseModel
  ): PipelineStepViewModel {
    let response = new PipelineStepViewModel();
    response.setProperties(
      dto.id,
      dto.name,
      dto.pipelineStepStatusId,
      dto.shipperId
    );

    if (dto.pipelineStepStatusIdNavigation != null) {
      response.pipelineStepStatusIdNavigation = new PipelineStepStatusViewModel();
      response.pipelineStepStatusIdNavigation.setProperties(
        dto.pipelineStepStatusIdNavigation.id,
        dto.pipelineStepStatusIdNavigation.name
      );
    }
    if (dto.shipperIdNavigation != null) {
      response.shipperIdNavigation = new EmployeeViewModel();
      response.shipperIdNavigation.setProperties(
        dto.shipperIdNavigation.firstName,
        dto.shipperIdNavigation.id,
        dto.shipperIdNavigation.isSalesPerson,
        dto.shipperIdNavigation.isShipper,
        dto.shipperIdNavigation.lastName
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStepViewModel
  ): Api.PipelineStepClientRequestModel {
    let response = new Api.PipelineStepClientRequestModel();
    response.setProperties(
      model.id,
      model.name,
      model.pipelineStepStatusId,
      model.shipperId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>eae456c41cc4dfc1b079eb577304dfbd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/