import moment from 'moment'


export default class ScrapReasonViewModel {
    modifiedDate:any;
name:string;
scrapReasonID:number;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.scrapReasonID = 0;

    }

	setProperties(modifiedDate : any,name : string,scrapReasonID : number) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.scrapReasonID = moment(scrapReasonID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>0b24e4dd31f8cf68998e254baf3346ff</Hash>
</Codenesium>*/