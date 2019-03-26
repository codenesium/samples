import * as Api from '../../api/models';
import NoteViewModel from './noteViewModel';
import CallViewModel from '../call/callViewModel';
import OfficerViewModel from '../officer/officerViewModel';
export default class NoteMapper {
  mapApiResponseToViewModel(dto: Api.NoteClientResponseModel): NoteViewModel {
    let response = new NoteViewModel();
    response.setProperties(
      dto.callId,
      dto.dateCreated,
      dto.id,
      dto.noteText,
      dto.officerId
    );

    if (dto.callIdNavigation != null) {
      response.callIdNavigation = new CallViewModel();
      response.callIdNavigation.setProperties(
        dto.callIdNavigation.addressId,
        dto.callIdNavigation.callDispositionId,
        dto.callIdNavigation.callStatusId,
        dto.callIdNavigation.callString,
        dto.callIdNavigation.callTypeId,
        dto.callIdNavigation.dateCleared,
        dto.callIdNavigation.dateCreated,
        dto.callIdNavigation.dateDispatched,
        dto.callIdNavigation.id,
        dto.callIdNavigation.quickCallNumber
      );
    }
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

    return response;
  }

  mapViewModelToApiRequest(model: NoteViewModel): Api.NoteClientRequestModel {
    let response = new Api.NoteClientRequestModel();
    response.setProperties(
      model.callId,
      model.dateCreated,
      model.id,
      model.noteText,
      model.officerId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>4fa3bb84087ae836db806c939e93dc4e</Hash>
</Codenesium>*/