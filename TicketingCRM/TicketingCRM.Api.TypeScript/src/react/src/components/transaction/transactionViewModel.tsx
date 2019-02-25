import moment from 'moment';
import TransactionStatusViewModel from '../transactionStatus/transactionStatusViewModel';

export default class TransactionViewModel {
  amount: number;
  gatewayConfirmationNumber: string;
  id: number;
  transactionStatusId: number;
  transactionStatusIdEntity: string;
  transactionStatusIdNavigation?: TransactionStatusViewModel;

  constructor() {
    this.amount = 0;
    this.gatewayConfirmationNumber = '';
    this.id = 0;
    this.transactionStatusId = 0;
    this.transactionStatusIdEntity = '';
    this.transactionStatusIdNavigation = new TransactionStatusViewModel();
  }

  setProperties(
    amount: number,
    gatewayConfirmationNumber: string,
    id: number,
    transactionStatusId: number
  ): void {
    this.amount = amount;
    this.gatewayConfirmationNumber = gatewayConfirmationNumber;
    this.id = id;
    this.transactionStatusId = transactionStatusId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>0004300ea2a095a280d246ed8cf95802</Hash>
</Codenesium>*/