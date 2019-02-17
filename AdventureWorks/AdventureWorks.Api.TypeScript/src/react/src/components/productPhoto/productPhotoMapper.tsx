import * as Api from '../../api/models';
import ProductPhotoViewModel from './productPhotoViewModel';
export default class ProductPhotoMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductPhotoClientResponseModel
  ): ProductPhotoViewModel {
    let response = new ProductPhotoViewModel();
    response.setProperties(
      dto.largePhoto,
      dto.largePhotoFileName,
      dto.modifiedDate,
      dto.productPhotoID,
      dto.thumbNailPhoto,
      dto.thumbnailPhotoFileName
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ProductPhotoViewModel
  ): Api.ProductPhotoClientRequestModel {
    let response = new Api.ProductPhotoClientRequestModel();
    response.setProperties(
      model.largePhoto,
      model.largePhotoFileName,
      model.modifiedDate,
      model.productPhotoID,
      model.thumbNailPhoto,
      model.thumbnailPhotoFileName
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>76d06dcb1c4fc04c2bf58c7a0027fed0</Hash>
</Codenesium>*/