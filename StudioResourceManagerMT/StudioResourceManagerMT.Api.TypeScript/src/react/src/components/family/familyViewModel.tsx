import moment from 'moment';

export default class FamilyViewModel {
  id: number;
  note: string;
  primaryContactEmail: string;
  primaryContactFirstName: string;
  primaryContactLastName: string;
  primaryContactPhone: string;

  constructor() {
    this.id = 0;
    this.note = '';
    this.primaryContactEmail = '';
    this.primaryContactFirstName = '';
    this.primaryContactLastName = '';
    this.primaryContactPhone = '';
  }

  setProperties(
    id: number,
    note: string,
    primaryContactEmail: string,
    primaryContactFirstName: string,
    primaryContactLastName: string,
    primaryContactPhone: string
  ): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.note = moment(note, 'YYYY-MM-DD');
    this.primaryContactEmail = moment(primaryContactEmail, 'YYYY-MM-DD');
    this.primaryContactFirstName = moment(
      primaryContactFirstName,
      'YYYY-MM-DD'
    );
    this.primaryContactLastName = moment(primaryContactLastName, 'YYYY-MM-DD');
    this.primaryContactPhone = moment(primaryContactPhone, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>ca286a416d7c04cf0f0b24f95b9365b8</Hash>
</Codenesium>*/