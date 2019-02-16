import TicketStatuViewModel from '../ticketStatu/ticketStatuViewModel';

export default class TicketViewModel {
  id: number;
  publicId: string;
  ticketStatusId: number;
  ticketStatusIdEntity: string;
  ticketStatusIdNavigation?: TicketStatuViewModel;

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
    return String();
  }
}


/*<Codenesium>
    <Hash>68de00ef4eaa287e8b18483368eb95ad</Hash>
</Codenesium>*/