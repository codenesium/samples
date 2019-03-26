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
    this.name = name;
    this.phoneNumberTypeID = phoneNumberTypeID;
  }

  toDisplay(): string {
    return String(this.modifiedDate);
  }
}


/*<Codenesium>
    <Hash>deb10ea62d6eb91699324b185e4cd349</Hash>
</Codenesium>*/