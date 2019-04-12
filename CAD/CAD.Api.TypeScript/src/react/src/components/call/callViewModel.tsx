import moment from 'moment';
import AddressViewModel from '../address/addressViewModel';
import CallDispositionViewModel from '../callDisposition/callDispositionViewModel';
import CallStatusViewModel from '../callStatus/callStatusViewModel';
import CallTypeViewModel from '../callType/callTypeViewModel';

export default class CallViewModel {
  addressId: number;
  addressIdEntity: string;
  addressIdNavigation?: AddressViewModel;
  callDispositionId: number;
  callDispositionIdEntity: string;
  callDispositionIdNavigation?: CallDispositionViewModel;
  callStatusId: number;
  callStatusIdEntity: string;
  callStatusIdNavigation?: CallStatusViewModel;
  callString: string;
  callTypeId: number;
  callTypeIdEntity: string;
  callTypeIdNavigation?: CallTypeViewModel;
  dateCleared: any;
  dateCreated: any;
  dateDispatched: any;
  id: number;
  quickCallNumber: number;

  constructor() {
    this.addressId = 0;
    this.addressIdEntity = '';
    this.addressIdNavigation = undefined;
    this.callDispositionId = 0;
    this.callDispositionIdEntity = '';
    this.callDispositionIdNavigation = undefined;
    this.callStatusId = 0;
    this.callStatusIdEntity = '';
    this.callStatusIdNavigation = undefined;
    this.callString = '';
    this.callTypeId = 0;
    this.callTypeIdEntity = '';
    this.callTypeIdNavigation = undefined;
    this.dateCleared = undefined;
    this.dateCreated = undefined;
    this.dateDispatched = undefined;
    this.id = 0;
    this.quickCallNumber = 0;
  }

  setProperties(
    addressId: number,
    callDispositionId: number,
    callStatusId: number,
    callString: string,
    callTypeId: number,
    dateCleared: any,
    dateCreated: any,
    dateDispatched: any,
    id: number,
    quickCallNumber: number
  ): void {
    this.addressId = addressId;
    this.callDispositionId = callDispositionId;
    this.callStatusId = callStatusId;
    this.callString = callString;
    this.callTypeId = callTypeId;
    this.dateCleared = moment(dateCleared, 'YYYY-MM-DD');
    this.dateCreated = moment(dateCreated, 'YYYY-MM-DD');
    this.dateDispatched = moment(dateDispatched, 'YYYY-MM-DD');
    this.id = id;
    this.quickCallNumber = quickCallNumber;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>3fd010b819070e1a4a0992315a5b20e0</Hash>
</Codenesium>*/