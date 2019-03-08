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
		this.countryId = countryId;
this.detail = detail;
this.id = id;

	}

	toDisplay() : string
	{
		return String(this.countryId);
	}
};

/*<Codenesium>
    <Hash>f43e9f7ffcc331b8f150d333a2746e33</Hash>
</Codenesium>*/