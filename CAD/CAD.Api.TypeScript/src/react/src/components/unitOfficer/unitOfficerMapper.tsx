import * as Api from '../../api/models';
import UnitOfficerViewModel from './unitOfficerViewModel';
import OfficerViewModel from '../officer/officerViewModel';
import UnitViewModel from '../unit/unitViewModel';
export default class UnitOfficerMapper {
  mapApiResponseToViewModel(
    dto: Api.UnitOfficerClientResponseModel
  ): UnitOfficerViewModel {
    let response = new UnitOfficerViewModel();
    response.setProperties(dto.id, dto.officerId, dto.unitId);

    if (dto.officerIdNavigation != null) {
      response.officerIdNavigation = new OfficerViewModel();
      response.officerIdNavigation.setProperties(
        dto.officerIdNavigation.badge,
        dto.officerIdNavigation.email,
        dto.officerIdNavigation.firstName,
        dto.officerIdNavigation.id,
        dto.officerIdNavigation.lastName,
        dto.officerIdNavigation.password
      );
    }
    if (dto.unitIdNavigation != null) {
      response.unitIdNavigation = new UnitViewModel();
      response.unitIdNavigation.setProperties(
        dto.unitIdNavigation.callSign,
        dto.unitIdNavigation.id
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: UnitOfficerViewModel
  ): Api.UnitOfficerClientRequestModel {
    let response = new Api.UnitOfficerClientRequestModel();
    response.setProperties(model.id, model.officerId, model.unitId);
    return response;
  }
}


/*<Codenesium>
    <Hash>468604b0fcf64cacb795693b52973219</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/