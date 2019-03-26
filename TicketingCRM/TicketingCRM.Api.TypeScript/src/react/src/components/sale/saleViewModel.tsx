import moment from 'moment';
import TransactionViewModel from '../transaction/transactionViewModel';

export default class SaleViewModel {
  id: number;
  ipAddress: string;
  note: string;
  saleDate: any;
  transactionId: number;
  transactionIdEntity: string;
  transactionIdNavigation?: TransactionViewModel;

  constructor() {
    this.id = 0;
    this.ipAddress = '';
    this.note = '';
    this.saleDate = undefined;
    this.transactionId = 0;
    this.transactionIdEntity = '';
    this.transactionIdNavigation = undefined;
  }

  setProperties(
    id: number,
    ipAddress: string,
    note: string,
    saleDate: any,
    transactionId: number
  ): void {
    this.id = id;
    this.ipAddress = ipAddress;
    this.note = note;
    this.saleDate = moment(saleDate, 'YYYY-MM-DD');
    this.transactionId = transactionId;
  }

  toDisplay(): string {
    return String(this.transactionId);
  }
}


/*<Codenesium>
    <Hash>2cfd29e24ce4802bacf6e629d1bb3e58</Hash>
</Codenesium>*/