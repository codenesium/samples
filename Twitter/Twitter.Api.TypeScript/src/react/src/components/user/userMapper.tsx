import * as Api from '../../api/models';
import UserViewModel from './userViewModel';
import LocationViewModel from '../location/locationViewModel';
export default class UserMapper {
  mapApiResponseToViewModel(dto: Api.UserClientResponseModel): UserViewModel {
    let response = new UserViewModel();
    response.setProperties(
      dto.bioImgUrl,
      dto.birthday,
      dto.contentDescription,
      dto.email,
      dto.fullName,
      dto.headerImgUrl,
      dto.interest,
      dto.locationLocationId,
      dto.password,
      dto.phoneNumber,
      dto.privacy,
      dto.userId,
      dto.username,
      dto.website
    );

    if (dto.locationLocationIdNavigation != null) {
      response.locationLocationIdNavigation = new LocationViewModel();
      response.locationLocationIdNavigation.setProperties(
        dto.locationLocationIdNavigation.gpsLat,
        dto.locationLocationIdNavigation.gpsLong,
        dto.locationLocationIdNavigation.locationId,
        dto.locationLocationIdNavigation.locationName
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: UserViewModel): Api.UserClientRequestModel {
    let response = new Api.UserClientRequestModel();
    response.setProperties(
      model.bioImgUrl,
      model.birthday,
      model.contentDescription,
      model.email,
      model.fullName,
      model.headerImgUrl,
      model.interest,
      model.locationLocationId,
      model.password,
      model.phoneNumber,
      model.privacy,
      model.userId,
      model.username,
      model.website
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>12f1c631eeaea1a0eb8bc72429fd6d70</Hash>
</Codenesium>*/