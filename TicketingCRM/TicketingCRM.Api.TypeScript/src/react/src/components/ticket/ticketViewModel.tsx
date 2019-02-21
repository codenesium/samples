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
    this.id = moment(id, 'YYYY-MM-DD');
    this.publicId = publicId;
    this.ticketStatusId = ticketStatusId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>0cb2aa3edce68cce20e7188f1a475852</Hash>
</Codenesium>*/