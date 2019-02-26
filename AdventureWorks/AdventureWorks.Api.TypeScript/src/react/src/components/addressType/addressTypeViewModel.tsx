import moment from 'moment'


export default class AddressTypeViewModel {
    addressTypeID:number;
modifiedDate:any;
name:string;
rowguid:any;

    constructor() {
		this.addressTypeID = 0;
this.modifiedDate = undefined;
this.name = '';
this.rowguid = undefined;

    }

	setProperties(addressTypeID : number,modifiedDate : any,name : string,rowguid : any) : void
	{
		this.addressTypeID = moment(addressTypeID,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>e22ef1dc4204e6f7a397bd97d989ba29</Hash>
</Codenesium>*/