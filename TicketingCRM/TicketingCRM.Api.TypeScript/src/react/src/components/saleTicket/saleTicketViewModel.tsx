import SaleViewModel from '../sale/saleViewModel';
import TicketViewModel from '../ticket/ticketViewModel';

export default class SaleTicketViewModel {
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
    return String();
  }
}


/*<Codenesium>
    <Hash>fee41aaff0f38d2f175a27639a43db85</Hash>
</Codenesium>*/