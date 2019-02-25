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
    this.businessEntityIDNavigation = new PersonViewModel();
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
    <Hash>caf14b182e774ecb26b57d6091c9b8da</Hash>
</Codenesium>*/