import moment from 'moment';

export default class VPersonViewModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }

  toDisplay(): string {
    return String(this.personName);
  }
}


/*<Codenesium>
    <Hash>4ec19415cfc2ffcf3331a81a0b02c121</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/