import moment from 'moment'


export default class PostHistoryTypesViewModel {
    id:number;
rwType:string;

    constructor() {
		this.id = 0;
this.rwType = '';

    }

	setProperties(id : number,rwType : string) : void
	{
		this.id = id;
this.rwType = rwType;

	}

	toDisplay() : string
	{
		return String(this.rwType);
	}
};

/*<Codenesium>
    <Hash>c2a43cf9d204a4fe3ea7e7ece1b1e0bf</Hash>
</Codenesium>*/