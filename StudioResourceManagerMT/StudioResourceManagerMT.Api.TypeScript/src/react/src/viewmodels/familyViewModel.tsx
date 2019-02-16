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
    isDeleted: boolean,
    note: string,
    primaryContactEmail: string,
    primaryContactFirstName: string,
    primaryContactLastName: string,
    primaryContactPhone: string,
    tenantId: number
  ): void {
    this.id = id;
    this.isDeleted = isDeleted;
    this.note = note;
    this.primaryContactEmail = primaryContactEmail;
    this.primaryContactFirstName = primaryContactFirstName;
    this.primaryContactLastName = primaryContactLastName;
    this.primaryContactPhone = primaryContactPhone;
    this.tenantId = tenantId;
  }
}


/*<Codenesium>
    <Hash>4765340775fa53802faa628b32a03fac</Hash>
</Codenesium>*/