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
}


/*<Codenesium>
    <Hash>c30fca29ec6bfeeab26606fb1e9a82db</Hash>
</Codenesium>*/