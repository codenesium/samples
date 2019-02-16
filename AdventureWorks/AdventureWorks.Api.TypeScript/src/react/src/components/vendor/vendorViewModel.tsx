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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.preferredVendorStatu = preferredVendorStatu;
    this.purchasingWebServiceURL = purchasingWebServiceURL;
  }
}


/*<Codenesium>
    <Hash>064e0b20403608eb882cc2431db79e73</Hash>
</Codenesium>*/