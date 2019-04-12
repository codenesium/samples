import moment from 'moment';

export default class FamilyViewModel {
  id: number;
  notes: string;
  primaryContactEmail: string;
  primaryContactFirstName: string;
  primaryContactLastName: string;
  primaryContactPhone: string;

  constructor() {
    this.id = 0;
    this.notes = '';
    this.primaryContactEmail = '';
    this.primaryContactFirstName = '';
    this.primaryContactLastName = '';
    this.primaryContactPhone = '';
  }

  setProperties(
    id: number,
    notes: string,
    primaryContactEmail: string,
    primaryContactFirstName: string,
    primaryContactLastName: string,
    primaryContactPhone: string
  ): void {
    this.id = id;
    this.notes = notes;
    this.primaryContactEmail = primaryContactEmail;
    this.primaryContactFirstName = primaryContactFirstName;
    this.primaryContactLastName = primaryContactLastName;
    this.primaryContactPhone = primaryContactPhone;
  }

  toDisplay(): string {
    return String(this.primaryContactLastName);
  }
}


/*<Codenesium>
    <Hash>f53f3d24daa7f9f6117bbbaa0069e100</Hash>
</Codenesium>*/