import LinkViewModel from '../link/linkViewModel'
	

export default class LinkLogViewModel {
    dateEntered:any;
id:number;
linkId:number;
linkIdEntity : string;
linkIdNavigation? : LinkViewModel;
log:string;

    constructor() {
		this.dateEntered = undefined;
this.id = 0;
this.linkId = 0;
this.linkIdEntity = '';
this.linkIdNavigation = undefined;
this.log = '';

    }

	setProperties(dateEntered : any,id : number,linkId : number,log : string) : void
	{
		this.dateEntered = dateEntered;
this.id = id;
this.linkId = linkId;
this.log = log;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>6ca82055070dc4daf862b811e2058cf9</Hash>
</Codenesium>*/