import moment from 'moment'


export default class SalesReasonViewModel {
    modifiedDate:any;
name:string;
reasonType:string;
salesReasonID:number;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.reasonType = '';
this.salesReasonID = 0;

    }

	setProperties(modifiedDate : any,name : string,reasonType : string,salesReasonID : number) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.reasonType = moment(reasonType,'YYYY-MM-DD');
this.salesReasonID = moment(salesReasonID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>566338c2b203a3a37c41c67524de9005</Hash>
</Codenesium>*/