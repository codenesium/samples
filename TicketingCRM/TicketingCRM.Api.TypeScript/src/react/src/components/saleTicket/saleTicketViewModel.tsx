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
this.saleIdNavigation = undefined;
this.ticketId = 0;
this.ticketIdEntity = '';
this.ticketIdNavigation = undefined;

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
    <Hash>b8d3300b7bd93e7b99aa4ec9be927ef6</Hash>
</Codenesium>*/