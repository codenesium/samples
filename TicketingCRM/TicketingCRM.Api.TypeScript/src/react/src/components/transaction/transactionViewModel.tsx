import TransactionStatuViewModel from '../transactionStatu/transactionStatuViewModel';

export default class TransactionViewModel {
  amount: number;
  gatewayConfirmationNumber: string;
  id: number;
  transactionStatusId: number;
  transactionStatusIdEntity: string;
  transactionStatusIdNavigation?: TransactionStatuViewModel;

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
    return String();
  }
}


/*<Codenesium>
    <Hash>4f7fd915d579d37198a564adb0ab9ab7</Hash>
</Codenesium>*/