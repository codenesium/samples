import moment from 'moment';
import PersonViewModel from '../person/personViewModel';
import PersonTypeViewModel from '../personType/personTypeViewModel';

export default class CallPersonViewModel {
  id: number;
  note: string;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonViewModel;
  personTypeId: number;
  personTypeIdEntity: string;
  personTypeIdNavigation?: PersonTypeViewModel;

  constructor() {
    this.id = 0;
    this.note = '';
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = new PersonViewModel();
    this.personTypeId = 0;
    this.personTypeIdEntity = '';
    this.personTypeIdNavigation = new PersonTypeViewModel();
  }

  setProperties(
    id: number,
    note: string,
    personId: number,
    personTypeId: number
  ): void {
    this.id = id;
    this.note = note;
    this.personId = personId;
    this.personTypeId = personTypeId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>0a407d725b2fabd82d8e6e749444d961</Hash>
</Codenesium>*/