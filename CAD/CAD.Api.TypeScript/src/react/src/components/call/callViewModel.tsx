import moment from 'moment';
import AddressViewModel from '../address/addressViewModel';
import CallDispositionViewModel from '../callDisposition/callDispositionViewModel';
import CallStatuViewModel from '../callStatu/callStatuViewModel';
import CallTypeViewModel from '../callType/callTypeViewModel';

export default class CallViewModel {
  addressId: any;
  addressIdEntity: string;
  addressIdNavigation?: AddressViewModel;
  callDispositionId: any;
  callDispositionIdEntity: string;
  callDispositionIdNavigation?: CallDispositionViewModel;
  callStatusId: any;
  callStatusIdEntity: string;
  callStatusIdNavigation?: CallStatuViewModel;
  callString: string;
  callTypeId: any;
  callTypeIdEntity: string;
  callTypeIdNavigation?: CallTypeViewModel;
  dateCleared: any;
  dateCreated: any;
  dateDispatched: any;
  id: number;
  quickCallNumber: number;

  constructor() {
    this.addressId = undefined;
    this.addressIdEntity = '';
    this.addressIdNavigation = new AddressViewModel();
    this.callDispositionId = undefined;
    this.callDispositionIdEntity = '';
    this.callDispositionIdNavigation = new CallDispositionViewModel();
    this.callStatusId = undefined;
    this.callStatusIdEntity = '';
    this.callStatusIdNavigation = new CallStatuViewModel();
    this.callString = '';
    this.callTypeId = undefined;
    this.callTypeIdEntity = '';
    this.callTypeIdNavigation = new CallTypeViewModel();
    this.dateCleared = undefined;
    this.dateCreated = undefined;
    this.dateDispatched = undefined;
    this.id = 0;
    this.quickCallNumber = 0;
  }

  setProperties(
    addressId: any,
    callDispositionId: any,
    callStatusId: any,
    callString: string,
    callTypeId: any,
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
    this.dateCleared = dateCleared;
    this.dateCreated = dateCreated;
    this.dateDispatched = dateDispatched;
    this.id = id;
    this.quickCallNumber = quickCallNumber;
  }

  toDisplay(): string {
    return String(this.addressId);
  }
}


/*<Codenesium>
    <Hash>3ff96134766bef32943cfb718453410c</Hash>
</Codenesium>*/