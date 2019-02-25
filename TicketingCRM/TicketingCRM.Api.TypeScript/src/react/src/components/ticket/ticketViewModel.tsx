import moment from 'moment';
import TicketStatusViewModel from '../ticketStatus/ticketStatusViewModel';

export default class TicketViewModel {
  id: number;
  publicId: string;
  ticketStatusId: number;
  ticketStatusIdEntity: string;
  ticketStatusIdNavigation?: TicketStatusViewModel;

  constructor() {
    this.id = 0;
    this.publicId = '';
    this.ticketStatusId = 0;
    this.ticketStatusIdEntity = '';
    this.ticketStatusIdNavigation = new TicketStatusViewModel();
  }

  setProperties(id: number, publicId: string, ticketStatusId: number): void {
    this.id = id;
    this.publicId = publicId;
    this.ticketStatusId = ticketStatusId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>8fea0cf00ee0fdd8852195810916f2f0</Hash>
</Codenesium>*/