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
    <Hash>7ebbc4eec8b33933372043b51340d889</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/