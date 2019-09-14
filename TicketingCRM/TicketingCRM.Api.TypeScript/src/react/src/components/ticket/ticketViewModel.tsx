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
    this.ticketStatusIdNavigation = undefined;
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
    <Hash>90d98c441e8d21fbea307cd6e9197fff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/