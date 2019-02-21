import moment from 'moment'


export default class CountryRegionViewModel {
    countryRegionCode:string;
modifiedDate:any;
name:string;

    constructor() {
		this.countryRegionCode = '';
this.modifiedDate = undefined;
this.name = '';

    }

	setProperties(countryRegionCode : string,modifiedDate : any,name : string) : void
	{
		this.countryRegionCode = moment(countryRegionCode,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>ce592d7e7669ccc3dda653b54c3df64a</Hash>
</Codenesium>*/