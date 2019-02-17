import SalesPersonViewModel from '../salesPerson/salesPersonViewModel'
	

export default class StoreViewModel {
    businessEntityID:number;
demographic:string;
modifiedDate:any;
name:string;
rowguid:any;
salesPersonID:any;
salesPersonIDEntity : string;
salesPersonIDNavigation? : SalesPersonViewModel;

    constructor() {
		this.businessEntityID = 0;
this.demographic = '';
this.modifiedDate = undefined;
this.name = '';
this.rowguid = undefined;
this.salesPersonID = undefined;
this.salesPersonIDEntity = '';
this.salesPersonIDNavigation = undefined;

    }

	setProperties(businessEntityID : number,demographic : string,modifiedDate : any,name : string,rowguid : any,salesPersonID : any) : void
	{
		this.businessEntityID = businessEntityID;
this.demographic = demographic;
this.modifiedDate = modifiedDate;
this.name = name;
this.rowguid = rowguid;
this.salesPersonID = salesPersonID;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>6b023bcd413dab9b0956049a7654a0df</Hash>
</Codenesium>*/