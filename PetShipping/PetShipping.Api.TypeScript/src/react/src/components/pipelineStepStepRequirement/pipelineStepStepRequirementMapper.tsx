import * as Api from '../../api/models';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';
export default class PipelineStepStepRequirementMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStepStepRequirementClientResponseModel
  ): PipelineStepStepRequirementViewModel {
    let response = new PipelineStepStepRequirementViewModel();
    response.setProperties(
      dto.details,
      dto.id,
      dto.pipelineStepId,
      dto.requirementMet
    );

    if (dto.pipelineStepIdNavigation != null) {
      response.pipelineStepIdNavigation = new PipelineStepViewModel();
      response.pipelineStepIdNavigation.setProperties(
        dto.pipelineStepIdNavigation.id,
        dto.pipelineStepIdNavigation.name,
        dto.pipelineStepIdNavigation.pipelineStepStatusId,
        dto.pipelineStepIdNavigation.shipperId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStepStepRequirementViewModel
  ): Api.PipelineStepStepRequirementClientRequestModel {
    let response = new Api.PipelineStepStepRequirementClientRequestModel();
    response.setProperties(
      model.details,
      model.id,
      model.pipelineStepId,
      model.requirementMet
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b2e0d1c1093750b8c0cfd7ac48413965</Hash>
</Codenesium>*/