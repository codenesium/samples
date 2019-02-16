export default class PhoneNumberTypeViewModel {
  modifiedDate: any;
  name: string;
  phoneNumberTypeID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.phoneNumberTypeID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    phoneNumberTypeID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.phoneNumberTypeID = phoneNumberTypeID;
  }
}


/*<Codenesium>
    <Hash>dbc8d11c32c9a273fdfa8151d1d4040e</Hash>
</Codenesium>*/