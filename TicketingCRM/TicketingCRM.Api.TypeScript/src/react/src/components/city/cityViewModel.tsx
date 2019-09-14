import moment from 'moment';
import ProvinceViewModel from '../province/provinceViewModel';

export default class CityViewModel {
  id: number;
  name: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
  }

  setProperties(id: number, name: string, provinceId: number): void {
    this.id = id;
    this.name = name;
    this.provinceId = provinceId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>c7e0719cec49108812d609c108dd3c23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/