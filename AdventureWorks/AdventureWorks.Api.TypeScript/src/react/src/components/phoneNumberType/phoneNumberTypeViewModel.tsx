import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.phoneNumberTypeID = moment(phoneNumberTypeID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>f89a7b42772a076e9d3a7636af66109d</Hash>
</Codenesium>*/