import TicketStatusViewModel from '../ticketStatus/ticketStatusViewModel'
	

export default class TicketViewModel {
    id:number;
publicId:string;
ticketStatusId:number;
ticketStatusIdEntity : string;
ticketStatusIdNavigation? : TicketStatusViewModel;

    constructor() {
		this.id = 0;
this.publicId = '';
this.ticketStatusId = 0;
this.ticketStatusIdEntity = '';
this.ticketStatusIdNavigation = undefined;

    }

	setProperties(id : number,publicId : string,ticketStatusId : number) : void
	{
		this.id = id;
this.publicId = publicId;
this.ticketStatusId = ticketStatusId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>c341252eb9d90f64a9a72625bcbeade0</Hash>
</Codenesium>*/