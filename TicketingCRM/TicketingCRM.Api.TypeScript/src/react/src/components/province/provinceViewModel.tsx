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
this.countryIdNavigation = undefined;
this.id = 0;
this.name = '';

    }

	setProperties(countryId : number,id : number,name : string) : void
	{
		this.countryId = countryId;
this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>2ec5db59557353a7990ad6167dc7b422</Hash>
</Codenesium>*/