import * as Api from '../../api/models';
import StateProvinceViewModel from './stateProvinceViewModel';
import CountryRegionViewModel from '../countryRegion/countryRegionViewModel';
export default class StateProvinceMapper {
  mapApiResponseToViewModel(
    dto: Api.StateProvinceClientResponseModel
  ): StateProvinceViewModel {
    let response = new StateProvinceViewModel();
    response.setProperties(
      dto.countryRegionCode,
      dto.isOnlyStateProvinceFlag,
      dto.modifiedDate,
      dto.name,
      dto.rowguid,
      dto.stateProvinceCode,
      dto.stateProvinceID,
      dto.territoryID
    );

    if (dto.countryRegionCodeNavigation != null) {
      response.countryRegionCodeNavigation = new CountryRegionViewModel();
      response.countryRegionCodeNavigation.setProperties(
        dto.countryRegionCodeNavigation.countryRegionCode,
        dto.countryRegionCodeNavigation.modifiedDate,
        dto.countryRegionCodeNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: StateProvinceViewModel
  ): Api.StateProvinceClientRequestModel {
    let response = new Api.StateProvinceClientRequestModel();
    response.setProperties(
      model.countryRegionCode,
      model.isOnlyStateProvinceFlag,
      model.modifiedDate,
      model.name,
      model.rowguid,
      model.stateProvinceCode,
      model.stateProvinceID,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>5a3fde318fa6106779702a32457edd04</Hash>
</Codenesium>*/