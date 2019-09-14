import moment from 'moment';
import TransactionViewModel from '../transaction/transactionViewModel';

export default class SaleViewModel {
  id: number;
  ipAddress: string;
  notes: string;
  saleDate: any;
  transactionId: number;
  transactionIdEntity: string;
  transactionIdNavigation?: TransactionViewModel;

  constructor() {
    this.id = 0;
    this.ipAddress = '';
    this.notes = '';
    this.saleDate = undefined;
    this.transactionId = 0;
    this.transactionIdEntity = '';
    this.transactionIdNavigation = undefined;
  }

  setProperties(
    id: number,
    ipAddress: string,
    notes: string,
    saleDate: any,
    transactionId: number
  ): void {
    this.id = id;
    this.ipAddress = ipAddress;
    this.notes = notes;
    this.saleDate = moment(saleDate, 'YYYY-MM-DD');
    this.transactionId = transactionId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>adb54dfdba87732d7f07f11b97a41868</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/