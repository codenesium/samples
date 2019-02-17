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
    this.modifiedDate = modifiedDate;
    this.name = name;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>71a368589c9c3148351728d26677f888</Hash>
</Codenesium>*/