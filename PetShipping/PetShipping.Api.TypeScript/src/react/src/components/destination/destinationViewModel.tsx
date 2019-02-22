import moment from 'moment'
import CountryViewModel from '../country/countryViewModel'
	

export default class DestinationViewModel {
    countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryViewModel;
id:number;
name:string;
order:number;

    constructor() {
		this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = new CountryViewModel();
this.id = 0;
this.name = '';
this.order = 0;

    }

	setProperties(countryId : number,id : number,name : string,order : number) : void
	{
		this.countryId = moment(countryId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.order = moment(order,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>02898245ba76d7c9bc2e943b08233781</Hash>
</Codenesium>*/