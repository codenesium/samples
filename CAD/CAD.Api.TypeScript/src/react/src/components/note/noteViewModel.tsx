import moment from 'moment';
import CallViewModel from '../call/callViewModel';
import OfficerViewModel from '../officer/officerViewModel';

export default class NoteViewModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallViewModel;
  dateCreated: any;
  id: number;
  noteText: string;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = undefined;
    this.dateCreated = undefined;
    this.id = 0;
    this.noteText = '';
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(
    callId: number,
    dateCreated: any,
    id: number,
    noteText: string,
    officerId: number
  ): void {
    this.callId = callId;
    this.dateCreated = moment(dateCreated, 'YYYY-MM-DD');
    this.id = id;
    this.noteText = noteText;
    this.officerId = officerId;
  }

  toDisplay(): string {
    return String(this.callId);
  }
}


/*<Codenesium>
    <Hash>96f18a58210c13d412457a29d9efbca2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/