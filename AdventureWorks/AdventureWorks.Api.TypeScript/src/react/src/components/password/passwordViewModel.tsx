import moment from 'moment';
import PersonViewModel from '../person/personViewModel';

export default class PasswordViewModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: PersonViewModel;
  modifiedDate: any;
  passwordHash: string;
  passwordSalt: string;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
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
    this.businessEntityID = businessEntityID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.passwordHash = passwordHash;
    this.passwordSalt = passwordSalt;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.businessEntityID);
  }
}


/*<Codenesium>
    <Hash>b1c95ce7266896e3b4b52743884de206</Hash>
</Codenesium>*/