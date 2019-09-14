import * as Api from '../../api/models';
import MachineViewModel from './machineViewModel';
export default class MachineMapper {
  mapApiResponseToViewModel(
    dto: Api.MachineClientResponseModel
  ): MachineViewModel {
    let response = new MachineViewModel();
    response.setProperties(
      dto.description,
      dto.id,
      dto.jwtKey,
      dto.lastIpAddress,
      dto.machineGuid,
      dto.name
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: MachineViewModel
  ): Api.MachineClientRequestModel {
    let response = new Api.MachineClientRequestModel();
    response.setProperties(
      model.description,
      model.id,
      model.jwtKey,
      model.lastIpAddress,
      model.machineGuid,
      model.name
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2ecc89f82765ac258017559ca08c3213</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/