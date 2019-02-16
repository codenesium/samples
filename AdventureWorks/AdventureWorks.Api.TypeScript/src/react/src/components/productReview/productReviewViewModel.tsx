export default class ProductReviewViewModel {
  comment: string;
  emailAddress: string;
  modifiedDate: any;
  productID: number;
  productReviewID: number;
  rating: number;
  reviewDate: any;
  reviewerName: string;

  constructor() {
    this.comment = '';
    this.emailAddress = '';
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productReviewID = 0;
    this.rating = 0;
    this.reviewDate = undefined;
    this.reviewerName = '';
  }

  setProperties(
    comment: string,
    emailAddress: string,
    modifiedDate: any,
    productID: number,
    productReviewID: number,
    rating: number,
    reviewDate: any,
    reviewerName: string
  ): void {
    this.comment = comment;
    this.emailAddress = emailAddress;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.productReviewID = productReviewID;
    this.rating = rating;
    this.reviewDate = reviewDate;
    this.reviewerName = reviewerName;
  }
}


/*<Codenesium>
    <Hash>e9ccb703d74410dd3d067d92577e75ff</Hash>
</Codenesium>*/