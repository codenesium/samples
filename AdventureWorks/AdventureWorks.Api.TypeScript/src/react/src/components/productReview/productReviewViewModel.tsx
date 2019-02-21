import moment from 'moment';

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
    this.comment = moment(comment, 'YYYY-MM-DD');
    this.emailAddress = moment(emailAddress, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productID = moment(productID, 'YYYY-MM-DD');
    this.productReviewID = moment(productReviewID, 'YYYY-MM-DD');
    this.rating = moment(rating, 'YYYY-MM-DD');
    this.reviewDate = moment(reviewDate, 'YYYY-MM-DD');
    this.reviewerName = moment(reviewerName, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>643c7f7baf6ddf73390e2578d07a632e</Hash>
</Codenesium>*/