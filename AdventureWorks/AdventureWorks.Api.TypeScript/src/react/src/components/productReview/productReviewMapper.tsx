import * as Api from '../../api/models';
import ProductReviewViewModel from './productReviewViewModel';

export default class ProductReviewMapper {
  mapApiResponseToViewModel(
    dto: Api.ProductReviewClientResponseModel
  ): ProductReviewViewModel {
    let response = new ProductReviewViewModel();
    response.setProperties(
      dto.comment,
      dto.emailAddress,
      dto.modifiedDate,
      dto.productID,
      dto.productReviewID,
      dto.rating,
      dto.reviewDate,
      dto.reviewerName
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: ProductReviewViewModel
  ): Api.ProductReviewClientRequestModel {
    let response = new Api.ProductReviewClientRequestModel();
    response.setProperties(
      model.comment,
      model.emailAddress,
      model.modifiedDate,
      model.productID,
      model.productReviewID,
      model.rating,
      model.reviewDate,
      model.reviewerName
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b2ce90a5225a5fb25b7adaf2da655f1c</Hash>
</Codenesium>*/