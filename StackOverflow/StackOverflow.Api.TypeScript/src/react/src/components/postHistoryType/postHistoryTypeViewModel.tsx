import moment from 'moment'


export default class PostHistoryTypeViewModel {
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
    <Hash>44377c20d8fa8a5c762c6af13954b2a1</Hash>
</Codenesium>*/