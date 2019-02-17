import * as Api from '../../api/models';
import JobCandidateViewModel from './jobCandidateViewModel';
export default class JobCandidateMapper {
  mapApiResponseToViewModel(
    dto: Api.JobCandidateClientResponseModel
  ): JobCandidateViewModel {
    let response = new JobCandidateViewModel();
    response.setProperties(
      dto.businessEntityID,
      dto.jobCandidateID,
      dto.modifiedDate,
      dto.resume
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: JobCandidateViewModel
  ): Api.JobCandidateClientRequestModel {
    let response = new Api.JobCandidateClientRequestModel();
    response.setProperties(
      model.businessEntityID,
      model.jobCandidateID,
      model.modifiedDate,
      model.resume
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>6f7b9b5cc6fc731afdf11422be1cc35c</Hash>
</Codenesium>*/