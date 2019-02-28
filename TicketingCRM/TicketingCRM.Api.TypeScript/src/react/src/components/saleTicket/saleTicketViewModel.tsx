import moment from 'moment'
import SaleViewModel from '../sale/saleViewModel'
	import TicketViewModel from '../ticket/ticketViewModel'
	

export default class SaleTicketViewModel {
    id:number;
saleId:number;
saleIdEntity : string;
saleIdNavigation? : SaleViewModel;
ticketId:number;
ticketIdEntity : string;
ticketIdNavigation? : TicketViewModel;

    constructor() {
		this.id = 0;
this.saleId = 0;
this.saleIdEntity = '';
this.saleIdNavigation = new SaleViewModel();
this.ticketId = 0;
this.ticketIdEntity = '';
this.ticketIdNavigation = new TicketViewModel();

    }

	setProperties(id : number,saleId : number,ticketId : number) : void
	{
		this.id = id;
this.saleId = saleId;
this.ticketId = ticketId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>fad777290f79d2b34d5238c9f6845947</Hash>
</Codenesium>*/