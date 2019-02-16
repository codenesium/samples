import * as Api from '../../api/models';
import VenueViewModel from './venueViewModel';
import AdminViewModel from '../admin/adminViewModel';
import ProvinceViewModel from '../province/provinceViewModel';
export default class VenueMapper {
  mapApiResponseToViewModel(dto: Api.VenueClientResponseModel): VenueViewModel {
    let response = new VenueViewModel();
    response.setProperties(
      dto.address1,
      dto.address2,
      dto.adminId,
      dto.email,
      dto.facebook,
      dto.id,
      dto.name,
      dto.phone,
      dto.provinceId,
      dto.website
    );

    if (dto.adminIdNavigation != null) {
      response.adminIdNavigation = new AdminViewModel();
      response.adminIdNavigation.setProperties(
        dto.adminIdNavigation.email,
        dto.adminIdNavigation.firstName,
        dto.adminIdNavigation.id,
        dto.adminIdNavigation.lastName,
        dto.adminIdNavigation.password,
        dto.adminIdNavigation.phone,
        dto.adminIdNavigation.username
      );
    }
    if (dto.provinceIdNavigation != null) {
      response.provinceIdNavigation = new ProvinceViewModel();
      response.provinceIdNavigation.setProperties(
        dto.provinceIdNavigation.countryId,
        dto.provinceIdNavigation.id,
        dto.provinceIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: VenueViewModel): Api.VenueClientRequestModel {
    let response = new Api.VenueClientRequestModel();
    response.setProperties(
      model.address1,
      model.address2,
      model.adminId,
      model.email,
      model.facebook,
      model.id,
      model.name,
      model.phone,
      model.provinceId,
      model.website
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>9226d1da69e393e4c34a35cae5459746</Hash>
</Codenesium>*/