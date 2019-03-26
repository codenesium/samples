import moment from 'moment';
import ProductViewModel from '../product/productViewModel';

export default class ProductReviewViewModel {
  comment: string;
  emailAddress: string;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductViewModel;
  productReviewID: number;
  rating: number;
  reviewDate: any;
  reviewerName: string;

  constructor() {
    this.comment = '';
    this.emailAddress = '';
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productID = productID;
    this.productReviewID = productReviewID;
    this.rating = rating;
    this.reviewDate = moment(reviewDate, 'YYYY-MM-DD');
    this.reviewerName = reviewerName;
  }

  toDisplay(): string {
    return String(this.comments);
  }
}


/*<Codenesium>
    <Hash>b060208d0614075d39927d6c46d85e68</Hash>
</Codenesium>*/