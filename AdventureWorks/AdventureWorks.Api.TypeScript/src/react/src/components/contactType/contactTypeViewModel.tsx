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
    this.contactTypeID = moment(contactTypeID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>bce9558c66ba771a9ff264393442f0fb</Hash>
</Codenesium>*/