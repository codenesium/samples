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
    this.transactionStatusIdNavigation = undefined;
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
    <Hash>028fd09a92b7fb5feb5501ab8331dc67</Hash>
</Codenesium>*/