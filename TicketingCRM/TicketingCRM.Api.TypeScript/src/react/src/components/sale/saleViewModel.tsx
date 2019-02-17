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
    this.saleDate = saleDate;
    this.transactionId = transactionId;
  }

  toDisplay(): string {
    return String(this.transactionId);
  }
}


/*<Codenesium>
    <Hash>600cf651fd62ba7eb52b52c42970b177</Hash>
</Codenesium>*/