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
    this.transactionIdNavigation = new TransactionViewModel();
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
    <Hash>c0ab27c2d16791114b0e68a6fa4e11a7</Hash>
</Codenesium>*/