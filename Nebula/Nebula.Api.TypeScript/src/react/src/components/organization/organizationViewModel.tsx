import moment from 'moment';

export default class OrganizationViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b160ab517a45590aa7b28b262a15b30a</Hash>
</Codenesium>*/