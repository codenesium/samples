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
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.passwordHash = passwordHash;
    this.passwordSalt = passwordSalt;
    this.rowguid = rowguid;
  }
}


/*<Codenesium>
    <Hash>f6fb13d5494d6ccda120c8e869477fef</Hash>
</Codenesium>*/