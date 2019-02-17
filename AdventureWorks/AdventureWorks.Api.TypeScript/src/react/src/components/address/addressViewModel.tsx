export default class AddressViewModel {
    addressID:number;
addressLine1:string;
addressLine2:string;
city:string;
modifiedDate:any;
postalCode:string;
rowguid:any;
stateProvinceID:number;

    constructor() {
		this.addressID = 0;
this.addressLine1 = '';
this.addressLine2 = '';
this.city = '';
this.modifiedDate = undefined;
this.postalCode = '';
this.rowguid = undefined;
this.stateProvinceID = 0;

    }

	setProperties(addressID : number,addressLine1 : string,addressLine2 : string,city : string,modifiedDate : any,postalCode : string,rowguid : any,stateProvinceID : number) : void
	{
		this.addressID = addressID;
this.addressLine1 = addressLine1;
this.addressLine2 = addressLine2;
this.city = city;
this.modifiedDate = modifiedDate;
this.postalCode = postalCode;
this.rowguid = rowguid;
this.stateProvinceID = stateProvinceID;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>ccc3c4b9ef79a42d9c7ce183ac2c1d0d</Hash>
</Codenesium>*/