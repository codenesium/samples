import * as Api from '../../api/models';
import EventViewModel from './eventViewModel';
import CityViewModel from '../city/cityViewModel';
export default class EventMapper {
  mapApiResponseToViewModel(dto: Api.EventClientResponseModel): EventViewModel {
    let response = new EventViewModel();
    response.setProperties(
      dto.address1,
      dto.address2,
      dto.cityId,
      dto.date,
      dto.description,
      dto.endDate,
      dto.facebook,
      dto.id,
      dto.name,
      dto.startDate,
      dto.website
    );

    if (dto.cityIdNavigation != null) {
      response.cityIdNavigation = new CityViewModel();
      response.cityIdNavigation.setProperties(
        dto.cityIdNavigation.id,
        dto.cityIdNavigation.name,
        dto.cityIdNavigation.provinceId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: EventViewModel): Api.EventClientRequestModel {
    let response = new Api.EventClientRequestModel();
    response.setProperties(
      model.address1,
      model.address2,
      model.cityId,
      model.date,
      model.description,
      model.endDate,
      model.facebook,
      model.id,
      model.name,
      model.startDate,
      model.website
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>ba1bfeb16b9751141462e76616e39d1f</Hash>
</Codenesium>*/