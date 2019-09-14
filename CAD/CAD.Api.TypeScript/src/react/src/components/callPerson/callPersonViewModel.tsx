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
    this.personIdNavigation = undefined;
    this.personTypeId = 0;
    this.personTypeIdEntity = '';
    this.personTypeIdNavigation = undefined;
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
    <Hash>82638cfe5eee75fa16a9d7837cd67ce7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/