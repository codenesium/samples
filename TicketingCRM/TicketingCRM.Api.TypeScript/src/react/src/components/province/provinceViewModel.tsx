import moment from 'moment'
import CountryViewModel from '../country/countryViewModel'
	

export default class ProvinceViewModel {
    countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryViewModel;
id:number;
name:string;

    constructor() {
		this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = new CountryViewModel();
this.id = 0;
this.name = '';

    }

	setProperties(countryId : number,id : number,name : string) : void
	{
		this.countryId = countryId;
this.id = moment(id,'YYYY-MM-DD');
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>ed37ee4abc51e3f255d634e550c0e892</Hash>
</Codenesium>*/