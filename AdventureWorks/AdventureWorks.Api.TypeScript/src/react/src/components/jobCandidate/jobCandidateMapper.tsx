import * as Api from '../../api/models';
import JobCandidateViewModel from './jobCandidateViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';
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

    if (dto.businessEntityIDNavigation != null) {
      response.businessEntityIDNavigation = new EmployeeViewModel();
      response.businessEntityIDNavigation.setProperties(
        dto.businessEntityIDNavigation.birthDate,
        dto.businessEntityIDNavigation.businessEntityID,
        dto.businessEntityIDNavigation.currentFlag,
        dto.businessEntityIDNavigation.gender,
        dto.businessEntityIDNavigation.hireDate,
        dto.businessEntityIDNavigation.jobTitle,
        dto.businessEntityIDNavigation.loginID,
        dto.businessEntityIDNavigation.maritalStatu,
        dto.businessEntityIDNavigation.modifiedDate,
        dto.businessEntityIDNavigation.nationalIDNumber,
        dto.businessEntityIDNavigation.organizationLevel,
        dto.businessEntityIDNavigation.rowguid,
        dto.businessEntityIDNavigation.salariedFlag,
        dto.businessEntityIDNavigation.sickLeaveHour,
        dto.businessEntityIDNavigation.vacationHour
      );
    }

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
    <Hash>eed76cb4e6d274cd4d26968e67222efa</Hash>
</Codenesium>*/