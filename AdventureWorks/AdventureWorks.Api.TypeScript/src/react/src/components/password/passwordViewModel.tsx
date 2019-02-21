import moment from 'moment';

export default class PasswordViewModel {
  businessEntityID: number;
  modifiedDate: any;
  passwordHash: string;
  passwordSalt: string;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.modifiedDate = undefined;
    this.passwordHash = '';
    this.passwordSalt = '';
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    passwordHash: string,
    passwordSalt: string,
    rowguid: any
  ): void {
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.passwordHash = moment(passwordHash, 'YYYY-MM-DD');
    this.passwordSalt = moment(passwordSalt, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>7facb21e27e63b0a7b0941cedd6ea945</Hash>
</Codenesium>*/