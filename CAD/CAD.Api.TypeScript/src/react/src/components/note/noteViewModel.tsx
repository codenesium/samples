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
    this.callIdNavigation = new CallViewModel();
    this.dateCreated = undefined;
    this.id = 0;
    this.noteText = '';
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = new OfficerViewModel();
  }

  setProperties(
    callId: number,
    dateCreated: any,
    id: number,
    noteText: string,
    officerId: number
  ): void {
    this.callId = callId;
    this.dateCreated = dateCreated;
    this.id = id;
    this.noteText = noteText;
    this.officerId = officerId;
  }

  toDisplay(): string {
    return String(this.callId);
  }
}


/*<Codenesium>
    <Hash>7de6f31ef885006363d6dd3e84d9b4a5</Hash>
</Codenesium>*/