import moment from 'moment';

export default class ContactTypeViewModel {
  contactTypeID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.contactTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(contactTypeID: number, modifiedDate: any, name: string): void {
    this.contactTypeID = contactTypeID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>ced1a059cf0ce2f15c60e59e1b1d5f05</Hash>
</Codenesium>*/