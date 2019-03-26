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
    this.accountNumber = accountNumber;
    this.activeFlag = activeFlag;
    this.businessEntityID = businessEntityID;
    this.creditRating = creditRating;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.preferredVendorStatu = preferredVendorStatu;
    this.purchasingWebServiceURL = purchasingWebServiceURL;
  }

  toDisplay(): string {
    return String(this.accountNumber);
  }
}


/*<Codenesium>
    <Hash>fb5dc13d6c513711441f308c6e5078a8</Hash>
</Codenesium>*/