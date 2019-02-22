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
    this.id = moment(id, 'YYYY-MM-DD');
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
    <Hash>76bad278ba2b156497c23a5327d7d339</Hash>
</Codenesium>*/