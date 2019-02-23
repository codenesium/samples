import moment from 'moment'


export default class LinkTypeViewModel {
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
    <Hash>0ec808b123c49db46ec8a14a344395a7</Hash>
</Codenesium>*/