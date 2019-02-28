import moment from 'moment'


export default class ShipMethodViewModel {
    modifiedDate:any;
name:string;
rowguid:any;
shipBase:number;
shipMethodID:number;
shipRate:number;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.rowguid = undefined;
this.shipBase = 0;
this.shipMethodID = 0;
this.shipRate = 0;

    }

	setProperties(modifiedDate : any,name : string,rowguid : any,shipBase : number,shipMethodID : number,shipRate : number) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.shipBase = moment(shipBase,'YYYY-MM-DD');
this.shipMethodID = moment(shipMethodID,'YYYY-MM-DD');
this.shipRate = moment(shipRate,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>6750eca9497b2aa1753d1607bac442a8</Hash>
</Codenesium>*/