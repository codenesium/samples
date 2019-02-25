import moment from 'moment';

export default class VendorViewModel {
  accountNumber: string;
  activeFlag: boolean;
  businessEntityID: number;
  creditRating: number;
  modifiedDate: any;
  name: string;
  preferredVendorStatu: boolean;
  purchasingWebServiceURL: string;

  constructor() {
    this.accountNumber = '';
    this.activeFlag = false;
    this.businessEntityID = 0;
    this.creditRating = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.preferredVendorStatu = false;
    this.purchasingWebServiceURL = '';
  }

  setProperties(
    accountNumber: string,
    activeFlag: boolean,
    businessEntityID: number,
    creditRating: number,
    modifiedDate: any,
    name: string,
    preferredVendorStatu: boolean,
    purchasingWebServiceURL: string
  ): void {
    this.accountNumber = moment(accountNumber, 'YYYY-MM-DD');
    this.activeFlag = moment(activeFlag, 'YYYY-MM-DD');
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.creditRating = moment(creditRating, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.preferredVendorStatu = moment(preferredVendorStatu, 'YYYY-MM-DD');
    this.purchasingWebServiceURL = moment(
      purchasingWebServiceURL,
      'YYYY-MM-DD'
    );
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>ed5a16b8d71472b37591b4c51f81d708</Hash>
</Codenesium>*/