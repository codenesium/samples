import * as Api from '../../api/models';
import PersonViewModel from './personViewModel';
export default class PersonMapper {
  mapApiResponseToViewModel(
    dto: Api.PersonClientResponseModel
  ): PersonViewModel {
    let response = new PersonViewModel();
    response.setProperties(
      dto.firstName,
      dto.id,
      dto.lastName,
      dto.phone,
      dto.ssn
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: PersonViewModel
  ): Api.PersonClientRequestModel {
    let response = new Api.PersonClientRequestModel();
    response.setProperties(
      model.firstName,
      model.id,
      model.lastName,
      model.phone,
      model.ssn
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>cac8ce0f09512dbe1280d2eca738132f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/