import moment from 'moment';
import SaleViewModel from '../sale/saleViewModel';
import TicketViewModel from '../ticket/ticketViewModel';

export default class SaleTicketsViewModel {
  id: number;
  saleId: number;
  saleIdEntity: string;
  saleIdNavigation?: SaleViewModel;
  ticketId: number;
  ticketIdEntity: string;
  ticketIdNavigation?: TicketViewModel;

  constructor() {
    this.id = 0;
    this.saleId = 0;
    this.saleIdEntity = '';
    this.saleIdNavigation = undefined;
    this.ticketId = 0;
    this.ticketIdEntity = '';
    this.ticketIdNavigation = undefined;
  }

  setProperties(id: number, saleId: number, ticketId: number): void {
    this.id = id;
    this.saleId = saleId;
    this.ticketId = ticketId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>05657fc913f28207daa4bc0a18694f35</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/