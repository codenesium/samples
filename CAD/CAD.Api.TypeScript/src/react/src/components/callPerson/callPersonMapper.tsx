import * as Api from '../../api/models';
import CallPersonViewModel from './callPersonViewModel';
import PersonViewModel from '../person/personViewModel';
import PersonTypeViewModel from '../personType/personTypeViewModel';
export default class CallPersonMapper {
  mapApiResponseToViewModel(
    dto: Api.CallPersonClientResponseModel
  ): CallPersonViewModel {
    let response = new CallPersonViewModel();
    response.setProperties(dto.id, dto.note, dto.personId, dto.personTypeId);

    if (dto.personIdNavigation != null) {
      response.personIdNavigation = new PersonViewModel();
      response.personIdNavigation.setProperties(
        dto.personIdNavigation.firstName,
        dto.personIdNavigation.id,
        dto.personIdNavigation.lastName,
        dto.personIdNavigation.phone,
        dto.personIdNavigation.ssn
      );
    }
    if (dto.personTypeIdNavigation != null) {
      response.personTypeIdNavigation = new PersonTypeViewModel();
      response.personTypeIdNavigation.setProperties(
        dto.personTypeIdNavigation.id,
        dto.personTypeIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: CallPersonViewModel
  ): Api.CallPersonClientRequestModel {
    let response = new Api.CallPersonClientRequestModel();
    response.setProperties(
      model.id,
      model.note,
      model.personId,
      model.personTypeId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>bdb8aaba9ed4e1e190e6d93bc8651d6c</Hash>
</Codenesium>*/