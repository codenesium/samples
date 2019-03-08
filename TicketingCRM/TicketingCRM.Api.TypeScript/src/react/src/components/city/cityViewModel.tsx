import moment from 'moment'
import ProvinceViewModel from '../province/provinceViewModel'
	

export default class CityViewModel {
    id:number;
name:string;
provinceId:number;
provinceIdEntity : string;
provinceIdNavigation? : ProvinceViewModel;

    constructor() {
		this.id = 0;
this.name = '';
this.provinceId = 0;
this.provinceIdEntity = '';
this.provinceIdNavigation = new ProvinceViewModel();

    }

	setProperties(id : number,name : string,provinceId : number) : void
	{
		this.id = id;
this.name = name;
this.provinceId = provinceId;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>771dd72ed1651d37843995f946157200</Hash>
</Codenesium>*/