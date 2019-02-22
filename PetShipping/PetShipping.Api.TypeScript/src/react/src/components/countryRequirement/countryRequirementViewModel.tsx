import moment from 'moment'
import CountryViewModel from '../country/countryViewModel'
	

export default class CountryRequirementViewModel {
    countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryViewModel;
detail:string;
id:number;

    constructor() {
		this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = new CountryViewModel();
this.detail = '';
this.id = 0;

    }

	setProperties(countryId : number,detail : string,id : number) : void
	{
		this.countryId = moment(countryId,'YYYY-MM-DD');
this.detail = moment(detail,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>ba671c83874f6b20d8229c4e89027d05</Hash>
</Codenesium>*/